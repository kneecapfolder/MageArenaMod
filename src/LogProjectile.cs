using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class LogProjectile : MonoBehaviour
{
    public float speed = 12f;
    public float lifetime = 5f;

    private Rigidbody rb;

    void Awake() 
    {
        rb = GetComponent<Rigidbody>(); 
    }

    public void Launch(Vector3 direction)
    {
        rb.velocity = direction.normalized * speed;
        Destroy(gameObject, lifetime);
    }
}
