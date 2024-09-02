using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private LayerMask hittable;
    [SerializeField] public float distance;
    public float dmg;
    public bool rapidFire;
    public int worth;

    //Necessary for Weaponhandler to activate Skin on Equip
    private Renderer Mesh;

    public GameObject ShootAnim;
    public GameObject HitAnim;


    public Transform WeaponRoot;
    float spawnDistance = 1f; // distance from WeaponRoot on Instantiate

    public Transform BulletDestination;
    public AudioSource Source;


    private void Start()
    {
        Source = GetComponent<AudioSource>();
        Mesh = GetComponent<Renderer>();
    }

    public void Shoot()
    {
        if (bullet != null)
        {
            GameObject Projectile = Instantiate(bullet, WeaponRoot.transform.position, Quaternion.identity);
            //Set Hitlayer on Enemy
            var bulletData = Projectile.GetComponentInChildren<ProjectileScript>();
            bulletData.hitLayer = 6;
            //Set Bullet Direction
            Rigidbody BulletRb = Projectile.GetComponent<Rigidbody>();
            BulletRb.velocity = Vector3.right * bulletData.BulletSpeed;

            Source.Play();
        }
        else
        {
            HitRay();
        }
    }

    void HitRay()
    {
        bool hit;
        RaycastHit hitInfo;
        hit = Physics.Raycast(transform.position, Vector3.right, out hitInfo, distance, layerMask: hittable);
        if (hit)
        {
            HitAnim.transform.position = hitInfo.point;
            HitAnim.SetActive(true);

            HealthSystem hs = hitInfo.collider?.gameObject?.GetComponent<HealthSystem>();
            if (hs == null)
            {
                return;
            }
            hs?.TakeDamage(dmg * Time.deltaTime);
        }
        else
        {

            HitAnim.SetActive(false);
        }
    }

}
