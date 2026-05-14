#if UNITY_STANDALONE_WIN || MICROSOFT_GDK_SUPPORT
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Unity.Microsoft.GDK.Discovery;

namespace PlayFab.Tools
{
    [System.Serializable]
    internal class GdkVersionJson
    {
        public int GdkEdition;
    }

    [System.Serializable]
    internal class LegacyGdkVersionJson
    {
        public int Edition;
    }
    
    [InitializeOnLoad]
    public static class GdkUtility
    {
        private static bool s_isInitialized = false;
        private static bool s_hasWarnedMissingPreferredGdk = false;
        private static GdkEditionFileWatcher s_gdkEditionFileWatcher;

        static GdkUtility()
        {
            EditorApplication.quitting += OnEditorQuitting;

            // Use EditorApplication.update to delay the initialization slightly so as to avoid importing
            // during Editor initialization.
            // NOTE: `EditorApplication.delayCall` is not safe to use during `[InitializeOnLoad]` or domain reloads.
            EditorApplication.update += WaitForInitialization;
        }

        private static void WaitForInitialization()
        {
            if (!EditorApplication.isUpdating && !EditorApplication.isCompiling)
            {
                EditorApplication.update -= WaitForInitialization;

                if (!s_isInitialized)
                {
                    InitializeOnLoad();
                }
            }
        }

        private static void InitializeOnLoad()
        {
            if (s_isInitialized)
                return;

            s_isInitialized = true;
            
            EditorApplication.delayCall += () =>
            {
                // GDK Discovery package is now a guaranteed dependency, proceed directly to initialization
                try
                {
                    // Initialize GDK edition JSON file if it doesn't exist
                    InitializeGdkEditionJson();
                    
                    ProcessGdkSelection();
                    
                    // Initialize file watcher for GDK changes
                    if (s_gdkEditionFileWatcher == null)
                    {
                        InitializeGdkEditionFileWatcher();
                    }
                }
                catch (Exception ex)
                {
                    Debug.LogError($"[PlayFab.Tools.GdkUtility] Error during GDK initialization: {ex.Message}\n{ex.StackTrace}");
                }
            };
        }
        
        /// <summary>
        /// Cleanup method called when the editor is quitting
        /// </summary>
        private static void OnEditorQuitting()
        {
            CleanupResources();
        }
        
        /// <summary>
        /// Cleans up file watcher and other resources
        /// </summary>
        private static void CleanupResources()
        {
            try
            {
                s_gdkEditionFileWatcher?.Dispose();
                s_gdkEditionFileWatcher = null;
            }
            catch (Exception ex)
            {
                Debug.LogError($"[PlayFab.Tools.GdkUtility] Error during cleanup: {ex.Message}");
            }
        }
        
        private static void ProcessGdkSelection()
        {
            try
            {
                string gdkPath = GetGdkPath();
                
                if (string.IsNullOrEmpty(gdkPath))
                {
                    Debug.LogError("[PlayFab.Tools.GdkUtility] GDK path is null or empty.");
                    return;
                }

                // Create target directory
                if (!Directory.Exists(GdkConstants.TargetGdkPluginPath))
                {
                    Directory.CreateDirectory(GdkConstants.TargetGdkPluginPath);
                }

                // Copy GDK binaries to the target directory
                CopyGdkBinaries(gdkPath);
                
                // Refresh the AssetDatabase to recognize the new files
                AssetDatabase.Refresh();
            }
            catch (Exception ex)
            {
                Debug.LogError($"[PlayFab.Tools.GdkUtility] Error during GDK files copy: {ex.Message}\n{ex.StackTrace}");
            }
        }
        
        /// <summary>
        /// Tries to get the currently selected GDK path from the GdkEdition.json file using the discovery package
        /// Falls back to the package's preferred GDK, or the latest installed GDK when preferred is unavailable
        /// </summary>
        private static bool TryGetSelectedGdkPath(out string gdkPath)
        {
            gdkPath = string.Empty;
            
            try
            {
                // Get all discovered GDKs using the discovery package API
                var discoveredGdks = GdkEnumerator.DiscoveredGdks;
                if (discoveredGdks == null || !discoveredGdks.Any())
                {
                    Debug.LogWarning("[PlayFab.Tools.GdkUtility] No GDK installations found via discovery package");
                    return false;
                }

                WarnIfPreferredGdkMissing(discoveredGdks.Select(gdk => gdk.Edition));
                
                // Try to read the GdkEdition.json file to get the selected edition
                string gdkEditionJsonPath = Path.Combine(GdkConstants.TargetGdkPluginPath, GdkConstants.GdkEditionJsonFileName);
                int selectedEdition = -1;
                
                if (File.Exists(gdkEditionJsonPath))
                {
                    try
                    {
                        string jsonContent = File.ReadAllText(gdkEditionJsonPath);
                        int selectedGdkEdition = ReadSelectedGdkEdition(jsonContent);

                        if (selectedGdkEdition > 0)
                        {
                            selectedEdition = selectedGdkEdition;
                            
                            // Find the GDK with the matching edition
                            foreach (var gdk in discoveredGdks)
                            {
                                if (gdk.Edition == selectedEdition)
                                {
                                    gdkPath = Path.Combine(gdk.Path, gdk.Edition.ToString());
                                    return true;
                                }
                            }
                            
                            Debug.LogWarning($"[PlayFab.Tools.GdkUtility] GDK edition {selectedEdition} not found in discovered GDKs, using default GDK");
                        }
                        else
                        {
                            Debug.Log("[PlayFab.Tools.GdkUtility] GdkEdition.json did not contain a valid GDK edition, using default GDK");
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.LogWarning($"[PlayFab.Tools.GdkUtility] Error reading GdkEdition.json: {ex.Message}, using default GDK");
                    }
                }
                else
                {
                    Debug.Log("[PlayFab.Tools.GdkUtility] GdkEdition.json file not found, using default GDK");
                }
                
                // Prefer the package's validated GDK, then fall back to the latest installed GDK.
                var fallbackGdk = discoveredGdks
                    .OrderByDescending(gdk => gdk.Edition == GdkConstants.PreferredGdkEdition)
                    .ThenByDescending(gdk => gdk.Edition)
                    .FirstOrDefault();
                
                if (fallbackGdk.Path != null)
                {
                    gdkPath = Path.Combine(fallbackGdk.Path, fallbackGdk.Edition.ToString());

                    var jsonData = new GdkVersionJson { GdkEdition = fallbackGdk.Edition };
                    string jsonContent = JsonUtility.ToJson(jsonData, true);
                
                    File.WriteAllText(gdkEditionJsonPath, jsonContent);

                    return true;
                }
                
                return false;
            }
            catch (Exception ex)
            {
                Debug.LogError($"[PlayFab.Tools.GdkUtility] Error getting GDK path: {ex.Message}");
                return false;
            }
        }

        internal static int ReadSelectedGdkEdition(string jsonContent)
        {
            var gdkEditionData = JsonUtility.FromJson<GdkVersionJson>(jsonContent);
            if (gdkEditionData != null && gdkEditionData.GdkEdition > 0)
            {
                return gdkEditionData.GdkEdition;
            }

            var legacyGdkEditionData = JsonUtility.FromJson<LegacyGdkVersionJson>(jsonContent);
            if (legacyGdkEditionData != null && legacyGdkEditionData.Edition > 0)
            {
                return legacyGdkEditionData.Edition;
            }

            return -1;
        }

        private static void WarnIfPreferredGdkMissing(IEnumerable<int> discoveredEditions)
        {
            var editions = discoveredEditions
                .Distinct()
                .OrderByDescending(edition => edition)
                .ToList();

            if (s_hasWarnedMissingPreferredGdk || editions.Contains(GdkConstants.PreferredGdkEdition))
            {
                return;
            }

            string installedEditions = string.Join(", ", editions);
            Debug.LogWarning($"[PlayFab.Tools.GdkUtility] Preferred GDK edition {GdkConstants.PreferredGdkEdition} was not found in discovered GDKs ({installedEditions}); using the selected or latest installed GDK. Install GDK edition {GdkConstants.PreferredGdkEdition} for the validated PlayFab SDK configuration.");
            s_hasWarnedMissingPreferredGdk = true;
        }
        
        /// <summary>
        /// Gets the GDK path using the TryGetSelectedGdkPath method which handles JSON file reading and fallback logic
        /// </summary>
        /// <returns>The GDK path, or null if none found</returns>
        private static string GetGdkPath()
        {
            string gdkPath = null;
            
            // TryGetSelectedGdkPath now handles all fallback logic internally
            if (TryGetSelectedGdkPath(out gdkPath))
            {
                return gdkPath;
            }
            
            Debug.LogError("[PlayFab.Tools.GdkUtility] No GDK installations found on this machine.");
            return null;
        }
        
        /// <summary>
        /// Initializes the selected GDK edition file when the project does not have one yet.
        /// </summary>
        private static void InitializeGdkEditionJson()
        {
            string gdkEditionJsonPath = Path.Combine(GdkConstants.TargetGdkPluginPath, GdkConstants.GdkEditionJsonFileName);
            
            if (!File.Exists(gdkEditionJsonPath))
            {
                // Get the default GDK edition using the discovery package API
                var discoveredGdks = GdkEnumerator.DiscoveredGdks;
                if (discoveredGdks != null && discoveredGdks.Any())
                {
                    var fallbackGdk = discoveredGdks
                        .OrderByDescending(gdk => gdk.Edition == GdkConstants.PreferredGdkEdition)
                        .ThenByDescending(gdk => gdk.Edition)
                        .FirstOrDefault();
                    
                    if (fallbackGdk.Path != null)
                    {
                        // Create the JSON content
                        var gdkEditionData = new GdkVersionJson { GdkEdition = fallbackGdk.Edition };
                        string jsonContent = JsonUtility.ToJson(gdkEditionData, true);
                        
                        // Write the JSON file
                        Directory.CreateDirectory(Path.GetDirectoryName(gdkEditionJsonPath));
                        File.WriteAllText(gdkEditionJsonPath, jsonContent);
                        
                        // Refresh the asset database to show the new file in Unity
                        AssetDatabase.Refresh();
                    }
                }
            }
        }

        /// <summary>
        /// Initializes our own GDK file watcher to monitor for GDK edition changes
        /// </summary>
        private static void InitializeGdkEditionFileWatcher()
        {
            try
            {
                s_gdkEditionFileWatcher?.Dispose();

                if (!Directory.Exists(GdkConstants.TargetGdkPluginPath))
                {
                    Directory.CreateDirectory(GdkConstants.TargetGdkPluginPath);
                }

                s_gdkEditionFileWatcher = new GdkEditionFileWatcher(GdkConstants.TargetGdkPluginPath, GdkConstants.GdkEditionJsonFileName);
                s_gdkEditionFileWatcher.RegisterCallbacks(
                    onFileChanged: OnGdkEditionFileChanged,
                    onFileDeleted: OnGdkEditionFileDeleted
                );
            }
            catch (Exception ex)
            {
                Debug.LogError($"[PlayFab.Tools.GdkUtility] Error initializing GDK file watcher: {ex.Message}");
            }
        }
        
        /// <summary>
        /// Event handler for when the GDK edition file is changed
        /// </summary>
        private static void OnGdkEditionFileChanged(string filePath)
        {
            RecopyGdkBinariesOnChange();
        }
        
        /// <summary>
        /// Event handler for when the GDK edition file is deleted
        /// </summary>
        private static void OnGdkEditionFileDeleted(string filePath)
        {
            RecopyGdkBinariesOnChange();
        }
        
        /// <summary>
        /// Re-copies GDK binaries when a change is detected, with overwrite enabled
        /// </summary>
        private static void RecopyGdkBinariesOnChange()
        {
            try
            {
                string gdkPath = GetGdkPath();                
                if (!string.IsNullOrEmpty(gdkPath))
                {
                    // Copy with overwrite enabled to update existing binaries
                    CopyGdkBinaries(gdkPath, overwrite: true);
                    AssetDatabase.Refresh();
                }
                else
                {
                    Debug.LogError("[PlayFab.Tools.GdkUtility] Could not determine GDK path for re-copying binaries");
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"[PlayFab.Tools.GdkUtility] Error during GDK binaries re-copy: {ex.Message}\n{ex.StackTrace}");
            }
        }
        
        private static void CopyGdkBinaries(string gdkPath, bool overwrite = false)
        {
            // Try the GrdkInstallPath/GRDK/GameKit/Redist/x64 path first
            string binPath = Path.Combine(gdkPath, "windows", "bin", "x64");

            if (!Directory.Exists(binPath))
            {
                Debug.LogError($"[PlayFab.Tools.GdkUtility] GDK version older than 2510. PlayFab binaries not found: {binPath}");
                return;
            }

            // Check and copy each required binary
            foreach (var binaryName in GdkConstants.RequiredGdkBinaries)
            {
                string sourcePath = Path.Combine(binPath, binaryName);
                string destPath = Path.Combine(GdkConstants.TargetGdkPluginPath, binaryName);
                
                if (File.Exists(destPath) && !overwrite)
                {
                    continue;
                }

                if (File.Exists(sourcePath))
                {
                    try
                    {
                        File.Copy(sourcePath, destPath, true);
                    }
                    catch (Exception ex)
                    {
                        Debug.LogError($"[PlayFab.Tools.GdkUtility] Failed to copy {binaryName}: {ex.Message}");
                    }
                }
                else
                {
                    Debug.LogError($"[PlayFab.Tools.GdkUtility] Required binary not found: {sourcePath}");
                }
            }
        }
    }
}
#endif
