using System.Threading.Tasks;
using BlackMagicAPI;
using BepInEx.Logging;
using BlackMagicAPI.Enums;
using BlackMagicAPI.Modules.Spells;
using BlackMagicAPI.Helpers;
using UnityEngine;
using System.Reflection;
using System.IO;

public class LogSpellData : SpellData
{
    private static ManualLogSource Logger = BepInEx.Logging.Logger.CreateLogSource("FireBlast");


    public override SpellType SpellType => SpellType.Page;
    public override string Name => "Log";
    public override float Cooldown => 1.5f;
    public override Color GlowColor => new Color(0.75f, 0.4f, 0f);
    public override bool DebugForceSpawn => true;
    public override string[] SubNames => new string[] { "Log" };
    

    public override async Task<SpellLogic> GetLogicPrefab()
    {
        var go = new GameObject("SimpleLogLogic");
        var logic = go.AddComponent<LogSpellLogic>();

        return go.GetComponent<SpellLogic>();
    }    

    public override Texture2D GetMainTexture()
    {
        /* Texture2D tex = Assembly.GetExecutingAssembly().LoadTextureFromResources("MyMod.Resources.LogSpell_Main.png");
        Logger.LogInfo(tex == null
            ? "SPELL PAGE TEXTURE IS NULL"
            : $"SPELL PAGE TEXTURE LOADED: {tex.width}x{tex.height}"
        );
        
        return tex; */

        string resourceName = "MyMod.Resources.wall.png"; 

        Assembly assembly = typeof(LogSpellData).Assembly;
        Stream stream = assembly.GetManifestResourceStream(resourceName);

        if (stream == null)
        {
            Debug.LogError($"Failed to load embedded texture: {resourceName}");
            return null;
        }

        byte[] bytes = new byte[stream.Length];
        stream.Read(bytes, 0, bytes.Length);

        Texture2D tex = new Texture2D(2, 2);
        tex.LoadRawTextureData(bytes); // Load PNG bytes into Texture2D

        Logger.LogInfo(tex == null
            ? "SPELL PAGE TEXTURE IS NULL"
            : $"SPELL PAGE TEXTURE LOADED: {tex.width}x{tex.height}"
        );

        return tex;
    }



}