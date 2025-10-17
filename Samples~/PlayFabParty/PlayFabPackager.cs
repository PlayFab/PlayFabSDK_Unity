#if UNITY_EDITOR
using System;
using System.IO;
using UnityEditor;
using UnityEditor.Build;

namespace PlayFab
{
    public static class PlayFabPackager
    {
        private static readonly string[] PartySampleTestScenes = {
            "Assets/Tests/PlayFabParty/TestApp.unity"
        };

        [MenuItem("PlayFab/Party/Build/Party Sample App")]
        public static void MakeSampleAppBuild()
        {
            MakeBuild(PartySampleTestScenes, "App.exe");
        }

        private static void MakeBuild(string[] scenes, string packageFileName)
        {
            NamedBuildTarget buildTarget = NamedBuildTarget.Standalone;
            PlayerSettings.SetApplicationIdentifier(buildTarget, packageFileName);

            var appPackageFile = Path.Combine("../Output/WinApp", packageFileName);
            BuildPipeline.BuildPlayer(scenes, appPackageFile, BuildTarget.StandaloneWindows64, BuildOptions.None);

            if (!File.Exists(appPackageFile))
                throw new Exception("Target file did not build: " + appPackageFile);
        }
    }
}
#endif