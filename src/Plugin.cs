using BepInEx;
using MageAPI;
using UnityEngine;
using BlackMagicAPI.Modules.Spells;
using System.Reflection;
using BlackMagicAPI.Managers;


[BepInPlugin("com.yourname.mymod", "FireBlast Test", "1.0.0")]
public class Plugin : BaseUnityPlugin
{
    void Awake()
    {
        Logger.LogInfo("FireBlast Mod Loaded!");

        BlackMagicManager.RegisterSpell(this, typeof(FireBlastData), typeof(FireBlastLogic));

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

}
