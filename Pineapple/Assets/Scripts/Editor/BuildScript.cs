using UnityEditor;
using System.Linq;
using System.IO;
using System.Collections.Generic;

public static class BuildScript 
{
    private static string _buildLocation;

    public static void BuildWindows32()
    {
        SetupVariables();
        BuildPipeline.BuildPlayer(GetScenes(), _buildLocation + ".exe", BuildTarget.StandaloneWindows64, BuildOptions.None);
    }

    public static void BuildLinux()
    {
        SetupVariables();
        BuildPipeline.BuildPlayer(GetScenes(), _buildLocation, BuildTarget.StandaloneLinux64, BuildOptions.None);
    }

    public static void BuildMacOS()
    {
        SetupVariables();
        BuildPipeline.BuildPlayer(GetScenes(), _buildLocation + ".app", BuildTarget.StandaloneOSX, BuildOptions.None);
    }

    private static void SetupVariables()
    {
        if (!File.Exists("./buildManifest.txt"))
        {
            //There's no buildManifest.txt file set some defaults.
            PlayerSettings.productName = "MGP 1";
            PlayerSettings.companyName = "DADIU Team 2";
            PlayerSettings.forceSingleInstance = true;
            PlayerSettings.bundleVersion = "0.0.0.0";
            _buildLocation = "./build/";
        }
        else
        {
            // buildManifest file exists load it up and setup the variables.
            using (var fs = new FileStream("./buildManifest.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var sr = new StreamReader(fs))
                {
                    var fileData = new Dictionary<string, string>();
                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine().Split('=');
                        fileData.Add(line[0], line[1].Replace("\"", ""));
                    }

                    PlayerSettings.productName = fileData["ProductName"];
                    PlayerSettings.companyName = fileData["CompanyName"];
                    PlayerSettings.forceSingleInstance = true;
                    PlayerSettings.bundleVersion = fileData["Version"];
                    _buildLocation = fileData["BuildLocation"] + "/" + fileData["Version"] + "/" + fileData["ProductName"].Replace(" ", "_");
                }
            }
        }
    }

    private static string[] GetScenes()
    {
        return EditorBuildSettings.scenes.Where(s => s.enabled).Select(s => s.path).ToArray();
    }
}
