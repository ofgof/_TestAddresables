using System;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEditor.Build.Reporting;

public class Builder
{
    [MenuItem("Build/Android")]
    public static void BuildAndroid()
    {
        BuildReport report = BuildPipeline.BuildPlayer(
            new BuildPlayerOptions()
            {
                target = BuildTarget.Android,
                locationPathName = "artifacts/Android/Game.apk",
                scenes = (from scene in EditorBuildSettings.scenes where scene.enabled select scene.path).ToArray(),
            });
        BuildSummary summary = report.summary;

        if (summary.result == BuildResult.Succeeded)
        {
            Debug.Log("Android Build succeeded: " + summary.totalSize + " bytes");
            var scenes = (from scene in EditorBuildSettings.scenes where scene.enabled select scene.path).ToArray();
            Debug.Log("Android Build scenes: " + string.Join(", ", scenes));
        }
        else
        {
            Debug.Log("Android Build failed");
            throw new Exception("Android Build failed");
        }
    }
    [MenuItem("Build/Windows")]
    public static void BuildWindows()
    {
        BuildReport report = BuildPipeline.BuildPlayer(
            new BuildPlayerOptions()
            {
                target = BuildTarget.StandaloneWindows64,
                locationPathName = "artifacts/Windows/Game.exe",
                scenes = (from scene in EditorBuildSettings.scenes where scene.enabled select scene.path).ToArray(),
            });
        BuildSummary summary = report.summary;

        if (summary.result == BuildResult.Succeeded)
        {
            Debug.Log("Windows Build succeeded: " + summary.totalSize + " bytes");
            var scenes = (from scene in EditorBuildSettings.scenes where scene.enabled select scene.path).ToArray();
            Debug.Log("Windows Build scenes: " + string.Join(", ", scenes));
        }
        else
        {
            Debug.Log("Windows Build failed");
            throw new Exception("Windows Build failed");
        }
    }
}
