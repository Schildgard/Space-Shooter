using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    //Projectiles moves to the right until they hit a hittable target or 10 seconds have past,
    //which is more than enough time to be out of screen.
    private Rigidbody rb;
    public float damage = 10;
    public int hitLayer;
    public float BulletSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, 10f);
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == hitLayer)
        {
            var health = collision.gameObject.GetComponentInChildren<HealthSystem>();
            health.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
