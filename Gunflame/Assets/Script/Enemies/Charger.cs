using System.Collections;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Charger : EnemyScript
{
    //This Enemy moves towards player and when in range, stops and charges in player direction.
    [SerializeField] private float moveSpeed;
    [SerializeField] private float chargeRange;
    [SerializeField] private float chargeSpeed;

    private GameObject player;
    private Rigidbody rb;

    private Vector3 distanceToPlayer;
    private bool isCharging = false;

    void Start()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();
        GetTarget();
    }

    public void Update()
    {
        if (player != null)
        {
            distanceToPlayer = player.transform.position - transform.position;
            // Check if Player is in Charge Range
            if (SqrMagnitude(distanceToPlayer) <= chargeRange && !isCharging)
            {
                StartCoroutine(Charge());
            }
            else if(SqrMagnitude(distanceToPlayer) >= chargeRange && !isCharging)
            {
                GetTarget();
            }
        }
    }

    public void GetTarget()
    {
        if (player != null)
        {
            Vector3 DirectionVector = player.transform.position - transform.position;
            Vector3 normalizedDirection = Vector3.Normalize(DirectionVector);
            rb.velocity = normalizedDirection * moveSpeed;
        }
    }
    IEnumerator Charge()
    {
        isCharging = !isCharging;
        rb.velocity = Vector3.zero;
        yield return new WaitForSeconds(1f);
        if (player != null)
        {
            rb.velocity = GetNormalizedDistance(player.transform.position, gameObject.transform.position) * chargeSpeed;
        }
        yield return new WaitForSeconds(1f);
        ResetBehaviour();
    }

    void ResetBehaviour()
    {
        if (player == null)
        {
            return;
        }
        isCharging = false;
        Vector3 DirectionVector = Vector3.zero;
        Vector3 normalizedDirection = Vector3.zero;
        rb.velocity = Vector3.zero;

        //"got Position" bool makes sure that the position of the Player is only updated once, so while charging, he does not follow the Player.
        bool gotPosition = false;
        if (!gotPosition)
        {
            DirectionVector = player.transform.position - transform.position;
            normalizedDirection = Vector3.Normalize(DirectionVector);
            gotPosition = true;
        }
        rb.velocity = normalizedDirection * moveSpeed;
    }
}
