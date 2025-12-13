using System.Threading.Tasks;
using BlackMagicAPI;
using BlackMagicAPI.Enums;
using BlackMagicAPI.Modules.Spells;
using BlackMagicAPI.Helpers;
using UnityEngine;
using System.Reflection;
using System.IO;

public class FireBlastData : SpellData
{
    public override SpellType SpellType => SpellType.Page;
    public override string Name => "FireBlast";
    public override float Cooldown => 1.5f;
    public override Color GlowColor => Color.red;
    public override bool DebugForceSpawn => true;
    public override string[] SubNames => new string[] { "Fire", "Blast" };
    

    public override async Task<SpellLogic> GetLogicPrefab()
    {
        var go = new GameObject("SimpleFireballLogic");
        var logic = go.AddComponent<FireBlastLogic>();

        return go.GetComponent<SpellLogic>();
    }    

    public override Texture2D GetMainTexture()
    {
        return Assembly.GetExecutingAssembly().LoadTextureFromResources("MyMod.Resources.wall.png");


        /* string resourceName = "MyMod.Resources.wall.png";

        Assembly assembly = typeof(FireBlastData).Assembly;
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
        return tex; */
    }

}