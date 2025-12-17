using BlackMagicAPI;
using BlackMagicAPI.Modules.Spells;
using BepInEx.Logging;
using UnityEngine;
using System.Collections;

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
        GameObject log = GameObject.CreatePrimitive(PrimitiveType.Capsule);

        log.transform.SetParent(playerObj.transform, false);
        log.transform.localPosition = new Vector3(0, 0.2f, 1.5f);
        log.transform.rotation = Quaternion.LookRotation(viewDirectionVector);
        log.transform.localScale = new Vector3(0.6f, 0.6f, 2.5f);

        var rb = log.AddComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX |
                        RigidbodyConstraints.FreezeRotationZ;
        rb.useGravity = false;

        log.transform.SetParent(null);
        rb.velocity = viewDirectionVector.normalized * 12f;


        /* Transform cam = playerObj.GetComponentInChildren<Camera>(true)?.transform;

        if (cam == null)
        {
            Logger.LogError("Player camera not found!");
            return;
        }
        
        // if (page.IsOwnedByPlayer == null)
        // {
        //     Logger.LogError("Not Owner");
        //     return;
        // }


        Debug.Log("Casting Log Spell");


        Vector3 spawnPoint =
            Camera.main.transform.position +
            Camera.main.transform.forward * 2f;

        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = spawnPoint;
        cube.layer = 0;
        cube.transform.SetParent(playerObj.transform);

        // GameObject log = Instantiate(
        //     cube,
        //     spawnPoint,
        //     Quaternion.identity
        // );
 */
        return;


        // GameObject log = Instantiate(
        //     LogAssets.LogPrefab,
        //     spawnPoint,
        //     Quaternion.identity
        // );

        // Material mat = log.GetComponent<MeshRenderer>().material;
        // mat.shader = Shader.Find("Standard");
        // // mat.SetTexture("_MainTex", null);
        // mat.EnableKeyword("_EMISSION");
        // mat.SetColor("_EmissionColor", Color.red * 1f);
        

        // Debug.Log(log.GetComponent<MeshRenderer>().material.GetColor("_EmissionColor"));

        // Debug.Log("LOG PREFAB INSTANTIATED: " + log.name);


        
        if (LogAssets.LogPrefab == null)
        {
            Debug.LogError("Log prefab not assigned!");
            return;
        }
        
        Debug.Log("LogPrefab IS VALID");


        // Vector3 spawnPoint = playerObj.transform.position + Vector3.up * 1.2f + viewDirectionVector.normalized * 2f;
        
        // GameObject log = Instantiate(
            // LogAssets.LogPrefab, spawnPoint, Quaternion.LookRotation(viewDirectionVector)
        // );

        // log.AddComponent<LogProjectile>().Launch(viewDirectionVector);




        /* Debug.Log("Log spell cast!");
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

        Logger.LogInfo("Log spawned at " + spawnPoint); */

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
