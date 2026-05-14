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
    /// <summary>
    /// Unity Editor window for selecting GDK versions
    /// </summary>
    public class GdkVersionPickerWindow : EditorWindow
    {
        private const string WindowTitle = "Select GDK";

        private int _currentVersion = -1;
        private List<GdkVersionInfo> _availableVersions = new List<GdkVersionInfo>();
        private int _selectedVersionIndex = -1;
        private bool _isLoaded = false;
        
        [System.Serializable]
        private class GdkVersionInfo
        {
            public int Version;
            public string Path;
            public string DisplayName;
            
            public GdkVersionInfo(int version, string path)
            {
                Version = version;
                Path = path;
                DisplayName = GdkVersion.Format(version);
            }
        }
        
        [MenuItem("PlayFab/Select GDK")]
        public static void ShowWindow()
        {
            var window = GetWindow<GdkVersionPickerWindow>(WindowTitle);
            window.minSize = new Vector2(300, 120);
            window.Show();
        }
        
        private void OnEnable()
        {
            LoadData();
        }
        
        private void OnGUI()
        {
            if (!_isLoaded)
            {
                EditorGUILayout.LabelField("Loading GDK information...");
                return;
            }
            
            // GDK dropdown section
            EditorGUILayout.LabelField("Select GDK:", EditorStyles.boldLabel);
            
            if (_availableVersions.Count == 0)
            {
                EditorGUILayout.LabelField("  No GDK installs found");
            }
            else
            {
                // Create dropdown options
                string[] versionOptions = _availableVersions.Select(e => e.DisplayName).ToArray();
                
                // Show dropdown and handle selection changes
                int newSelectedIndex = EditorGUILayout.Popup("", _selectedVersionIndex, versionOptions);

                // If selection changed, update the GDK version
                if (newSelectedIndex != _selectedVersionIndex && newSelectedIndex >= 0)
                {
                    _selectedVersionIndex = newSelectedIndex;
                    SetGdkVersion(_availableVersions[_selectedVersionIndex].Version);
                }
            }
        }
        
        private void LoadData()
        {
            _isLoaded = false;
            _availableVersions.Clear();
            _selectedVersionIndex = -1;
            
            try
            {
                // Load available versions via reflection first
                LoadAvailableVersions();

                // Load current version from JSON
                _currentVersion = LoadCurrentVersionFromJson();

                // Set selected index to current version if found, otherwise default to latest (first in sorted list)
                if (_currentVersion >= 0)
                {
                    // Try to find the current version from JSON
                    for (int i = 0; i < _availableVersions.Count; i++)
                    {
                        if (_availableVersions[i].Version == _currentVersion)
                        {
                            _selectedVersionIndex = i;
                            break;
                        }
                    }
                }

                // If no version was found from JSON or JSON doesn't exist, default to latest (index 0)
                if (_selectedVersionIndex == -1 && _availableVersions.Count > 0)
                {
                    _selectedVersionIndex = 0; // Latest version (sorted newest first)
                    _currentVersion = _availableVersions[0].Version;
                }
                
                _isLoaded = true;
            }
            catch (Exception ex)
            {
                Debug.LogError($"[PlayFab.Tools.GdkVersionPickerWindow] LoadData error: {ex}");
            }
            
            Repaint();
        }
        
        private int LoadCurrentVersionFromJson()
        {
            string jsonPath = GetGdkVersionJsonPath();
            
            if (!File.Exists(jsonPath))
            {
                return -1;
            }
            
            try
            {
                string jsonContent = File.ReadAllText(jsonPath);
                return GdkUtility.ReadSelectedGdkEdition(jsonContent);
            }
            catch (Exception ex)
            {
                Debug.LogWarning($"[PlayFab.Tools.GdkVersionPickerWindow] Failed to read GDK version JSON: {ex.Message}");
                return -1;
            }
        }

        private void LoadAvailableVersions()
        {
            try
            {
                // Get discovered GDKs using the discovery package API directly
                var discoveredGdks = GdkEnumerator.DiscoveredGdks;
                
                foreach (var gdk in discoveredGdks)
                {
                    try
                    {
                        _availableVersions.Add(new GdkVersionInfo(gdk.Edition, gdk.Path));
                    }
                    catch (Exception ex)
                    {
                        Debug.LogWarning($"[PlayFab.Tools.GdkVersionPickerWindow] Failed to process GDK info: {ex.Message}");
                    }
                }
                
                // Sort by version number (newest first)
                _availableVersions.Sort((a, b) => b.Version.CompareTo(a.Version));
            }
            catch (Exception ex)
            {
                Debug.LogError($"[PlayFab.Tools.GdkVersionPickerWindow] Failed to load available GDK versions: {ex}");
            }
        }
        
        private void SetGdkVersion(int version)
        {
            try
            {
                string jsonPath = GetGdkVersionJsonPath();

                // Ensure directory exists
                string directory = Path.GetDirectoryName(jsonPath);
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                
                // Create JSON data
                var jsonData = new GdkVersionJson { GdkEdition = version };
                string jsonContent = JsonUtility.ToJson(jsonData, true);
                
                // Write to file
                File.WriteAllText(jsonPath, jsonContent);

                // Update current version
                _currentVersion = version;

                // Trigger asset database refresh to detect the JSON file change
                AssetDatabase.Refresh();
                
                Repaint();
            }
            catch (Exception ex)
            {
                Debug.LogError($"[PlayFab.Tools.GdkVersionPickerWindow] Failed to set GDK: {ex}");
            }
        }

        private string GetGdkVersionJsonPath()
        {
            return Path.Combine(GdkConstants.TargetGdkPluginPath, GdkConstants.GdkEditionJsonFileName);
        }
    }
}
#endif
