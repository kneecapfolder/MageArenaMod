using System.IO;
using BepInEx;
using UnityEngine;

public static class LogAssets
{
    public static GameObject LogPrefab;

    public static void Load()
    {
        string path = Path.Combine(Paths.PluginPath, "LogSpellMod", "Logspell");

        if (!File.Exists(path))
        {
            Debug.LogError("AssetBundle NOT found: " + path);
            return;
        }

        var bundle = AssetBundle.LoadFromFile(path);
        LogPrefab = bundle.LoadAsset<GameObject>("LogProjectile");
        
        Debug.Log(LogPrefab != null
            ? "Log prefab loaded successfully"
            : "FAILED to load Log prefab");
    }
}