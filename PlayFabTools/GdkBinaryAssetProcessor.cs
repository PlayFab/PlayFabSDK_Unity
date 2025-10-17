#if UNITY_STANDALONE_WIN || MICROSOFT_GDK_SUPPORT
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace PlayFab.Tools
{
    /// <summary>
    /// Post processes imported GDK binaries to ensure they are configured for both Editor and Standalone Windows platforms.
    /// 
    /// Unlike the GDK package's assembly processor which focuses on Editor-only compatibility,
    /// this processor configures binaries to work in both Editor and Standalone Windows builds.
    /// </summary>
    /// <remarks>
    /// This class inherits from AssetPostprocessor to handle post-processing of imported assets,
    /// specifically focusing on the required GDK binaries defined in GdkConstants.
    /// </remarks>
    internal class GdkBinaryAssetProcessor : AssetPostprocessor
    {
        /// <summary>
        /// Processes all assets after import, focusing on GDK binaries in the required list.
        /// </summary>
        /// <param name="importedAssets">Array of paths to imported assets.</param>
        /// <param name="deletedAssets">Array of paths to deleted assets. Not used.</param>
        /// <param name="movedAssets">Array of paths to moved assets. Not used.</param>
        /// <param name="movedFromAssetPaths">Array of old paths for moved assets. Not used.</param>
        /// <remarks>
        /// This method checks each imported asset against the required GDK binaries list.
        /// When found, the binary will be configured to be compatible with both Editor and Standalone Windows platforms.
        /// </remarks>
        static void OnPostprocessAllAssets(
            string[] importedAssets,
            string[] deletedAssets,
            string[] movedAssets,
            string[] movedFromAssetPaths)
        {
            foreach (var assetPath in importedAssets)
            {
                // Check if this asset is one of our required GDK binaries
                string fileName = Path.GetFileName(assetPath);
                if (!GdkConstants.RequiredGdkBinaries.Contains(fileName) ||
                    !assetPath.Contains(GdkConstants.TargetGdkPluginPath))
                {
                    continue;
                }

                var importer = AssetImporter.GetAtPath(assetPath) as PluginImporter;
                if (importer == null)
                {
                    Debug.LogWarning($"Could not get PluginImporter for GDK binary: {assetPath}");
                    return;
                }

                // Return early if already properly configured
                if (!importer.GetCompatibleWithAnyPlatform() &&
                    importer.GetCompatibleWithPlatform(BuildTarget.StandaloneWindows64) &&
                    importer.GetCompatibleWithEditor() &&
                    importer.GetEditorData("OS") == "Windows")
                {
                    return;
                }

                // Disable compatibility with any platform first
                importer.SetCompatibleWithAnyPlatform(false);

                // Enable Standalone Windows platforms
                importer.SetCompatibleWithPlatform(BuildTarget.StandaloneWindows64, true);

                // Enable Editor compatibility
                importer.SetCompatibleWithEditor(true);
                importer.SetPlatformData("Editor", "OS", "Windows");

                // Save and reimport the asset
                importer.SaveAndReimport();
            }
        }
    }
}
#endif
