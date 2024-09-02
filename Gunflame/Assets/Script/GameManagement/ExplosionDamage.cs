using UnityEngine;

public class ExplosionDamage : MonoBehaviour
{
    //Destroyed Enemies triggers Explosions which damages nearby enemies
    private SphereCollider col;
    [SerializeField] float radiusExtension;

    private void Awake()
    {
        col = GetComponent<SphereCollider>();
    }

    private void Update()
    {
        if (col.radius <= 52f)
        {
            col.radius += radiusExtension * Time.deltaTime;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6) 
        {
            other.GetComponent<HealthSystem>().TakeDamage(20);
        }
    }
}
