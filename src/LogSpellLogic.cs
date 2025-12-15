using BlackMagicAPI.Modules.Spells;
using BepInEx.Logging;
using UnityEngine;

public class LogSpellLogic : SpellLogic
{
    private static ManualLogSource Logger = BepInEx.Logging.Logger.CreateLogSource("FireBlast");

    public override void CastSpell(
        GameObject playerObj,
        PageController page,
        Vector3 spawnPos,
        Vector3 viewDirectionVector,
        int castingLevel
    )
    {
        Debug.Log("Log spell cast!");
        Vector3 spawnPoint = playerObj.transform.position + Vector3.up * 1.5f + viewDirectionVector.normalized * 2f;

        var log = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        log.transform.position = spawnPoint;
        log.transform.localScale = new Vector3(0.5f, 0.25f, 1f);
        log.transform.SetParent(playerObj.transform.parent);
        log.layer = LayerMask.NameToLayer("Spell");

        var rb = log.AddComponent<Rigidbody>();
        rb.useGravity = false;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        rb.velocity = viewDirectionVector.normalized * 12f;

        var renderer = log.GetComponent<Renderer>();
        renderer.material = new Material(Shader.Find("Standard"));
        renderer.material.color = Color.red;

        Destroy(log, 5f);

        Logger.LogInfo("Log spawned at " + spawnPoint);

        /* Debug.Log("FireBlast cast!");
        Vector3 spawnPoint = playerObj.transform.position + Vector3.up * 1.5f + viewDirectionVector.normalized * 1f;

        var ball = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        ball.transform.position = spawnPoint;
        ball.transform.localScale = Vector3.one * .5f;

        var rb = ball.AddComponent<Rigidbody>();
        rb.useGravity = false;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        rb.velocity = viewDirectionVector * 10f;

        var renderer = ball.GetComponent<Renderer>();
        renderer.material = new Material(Shader.Find("Standard"));
        renderer.material.color = Color.red;

        // Destroy(ball, 3f);
        
        Logger.LogInfo("get blasted at " + spawnPoint.ToString()); */
    }
}
