using BepInEx;
using MageAPI;
using UnityEngine;
using BlackMagicAPI.Modules.Spells;
using System.Reflection;
using BlackMagicAPI.Managers;


[BepInPlugin("com.yourname.mymod", "Log Spell Test", "1.0.0")]
public class Plugin : BaseUnityPlugin
{
    void Awake()
    {
        Logger.LogInfo("FireBlast Mod Loaded!");

        BlackMagicManager.RegisterSpell(this, typeof(LogSpellData), typeof(LogSpellLogic));

        // BlackMagicManager.PlayerIni


        // Example: cast spell on yourself from console
        // PlayerSpellManager.AddStartingSpell(typeof(FireBlastData));
        
        // string log = "FireBlast Mod Loaded! " + typeof(SpellData).Assembly.GetTypes().Length + " | ";
        // Log all spells discovered
        // foreach (var spellType in typeof(SpellData).Assembly.GetTypes())
        //     if (typeof(SpellData).IsAssignableFrom(spellType) && !spellType.IsAbstract)
        //         log += "| Found SpellData: " + spellType.FullName;
        
        // Logger.LogInfo(log);
    }

    
    /* public static Texture2D LoadTexture(string relativePath)
    {
        string fullPath = Path.Combine(Paths.PluginPath, relativePath);

        if (!File.Exists(fullPath))
        {
            Debug.LogError("Texture not found: " + fullPath);
            return null;
        }

        byte[] data = File.ReadAllBytes(fullPath);
        Texture2D tex = new Texture2D(2, 2, TextureFormat.RGBA32, false);
        tex.LoadImage(data);
        tex.filterMode = FilterMode.Bilinear;
        tex.wrapMode = TextureWrapMode.Clamp;

        return tex;
    } */
}
