using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class BuildScript
{
    //WebGL 빌드
    [MenuItem("Build/Build WebGL")]
    public static void PerformBuild()
    {

        string buildDirectory = "./Builds";
        if (!Directory.Exists(buildDirectory))
        {
            Directory.CreateDirectory(buildDirectory);
        }

        BuildPlayerOptions options = new BuildPlayerOptions();

        // Scene 추가
        List<string> scenes = new List<string>();
        foreach (var scene in EditorBuildSettings.scenes)
        {
            if(!scene.enabled) continue;
            scenes.Add(scene.path);
        }
        options.scenes = scenes.ToArray();

        // 타겟 경로
        options.locationPathName = "./Builds";

        // 빌드 타겟
        options.target = BuildTarget.WebGL;
        
        // 빌드
        BuildPipeline.BuildPlayer(options);
    }

}
