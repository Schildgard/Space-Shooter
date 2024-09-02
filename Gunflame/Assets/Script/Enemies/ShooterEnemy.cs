using System.Collections;
using UnityEngine;

public class ShooterEnemy : EnemyScript
{
    //This enemy patrols between two positions and shoots a projectile at player after arriving.
    private Rigidbody rg;
    private Transform playerTransform;
    private RobotFreeAnim robotAnimation;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float moveSpeed;

    private float actionTimer;
    private float actionCooldown = 2f;


    private Vector3 PointA;
    private Vector3 PointB;
    private Vector3 NextPoint;

    void Start()
    {
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        rg = GetComponent<Rigidbody>();
        PointA = this.transform.position;
        PointB = this.transform.Find("PointB").position;
        NextPoint = PointB;

        robotAnimation = GetComponentInChildren<RobotFreeAnim>();
    }

    public void Update()
    {
        if (actionTimer <= 0)
        {
            TriggerBehaviour(NextPoint);
        }
        else
        {
            actionTimer -= Time.deltaTime;
        }
    }

    void Shoot()
    {
        GameObject Projectile;
        if (playerTransform != null)
        {
            //Get Shooting Direction and spawn Projectile
            Vector3 Target = GetNormalizedDistance(playerTransform.position, transform.position);
            Projectile = Instantiate(bullet, transform.position, Quaternion.identity);
            //Set Player as hittable Target
            var bulletData = Projectile.GetComponentInChildren<ProjectileScript>();
            bulletData.hitLayer = 3;
            //Set Bullet Direction
            Rigidbody BulletRb = Projectile.GetComponent<Rigidbody>();
            BulletRb.velocity = Target * bulletData.BulletSpeed;
        }
    }


    void TriggerBehaviour(Vector3 _destination)
    {
        //Move to next Point
        Vector3 moveDirection = _destination - transform.position;
        rg.velocity = Vector3.Normalize(moveDirection) * moveSpeed;
        robotAnimation.animTriggered = true;

        // When arrive at point, Stop, Shoot and change next Point Position
        if (SqrMagnitude(moveDirection) < 0.1f)
        {
            robotAnimation.animTriggered = false;
            rg.velocity = Vector3.zero;

            StartCoroutine(Attack());

            if (CompareDistance(NextPoint, PointB) <= 1) // NextPoint == PointB
            {
                NextPoint = PointA;
            }
            else
            {
                NextPoint = PointB;
            }
            actionTimer = actionCooldown;
        }
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(1);
        Shoot();
    }
}

