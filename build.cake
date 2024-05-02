#addin nuget:?package=Cake.Unity&version=0.9.0
var target = Argument("target", "BuildAndroid");

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
    .Does(() =>
{
    CleanDirectory($"./artifacts");
});

Task("BuildAndroid")
    .IsDependentOn("Clean")
    .Does(() =>
{
    UnityEditor(2022, 3,
    new UnityEditorArguments
    {
        BatchMode = true,
        Quit = true,
        ProjectPath = ".",
        ExecuteMethod = "Builder.BuildAndroid",
        BuildTarget = BuildTarget.Android,
        LogFile = "./artifacts/Android/unity.log"
    },
    new UnityEditorSettings
    {
        RealTimeLog = true
    });
});
Task("BuildWindows")
    .Does(() =>
{
    UnityEditor(2022, 3,
    new UnityEditorArguments
    {
        BatchMode = true,
        Quit = true,
        ExecuteMethod = "Builder.BuildWindows",
        BuildTarget = BuildTarget.Win64,
        LogFile = "./artifacts/Windows/unity.log"
    },
    new UnityEditorSettings
    {
        RealTimeLog = true
    });
});


//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);