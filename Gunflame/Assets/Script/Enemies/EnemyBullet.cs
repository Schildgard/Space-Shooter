using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    //TO DO: Remove this entire script and change the Player Bullet to normal Bullet
    Rigidbody rb;
    [SerializeField] private LayerMask Hittable;

    public float damage = 10;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, 12f);

    }


    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == 3)
        {
            collision.gameObject.GetComponent<HealthSystem>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
