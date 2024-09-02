using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCharger : EnemyScript
{

    [SerializeField]
    Transform PointA;
    [SerializeField]
    Transform PointB;
    [SerializeField]
    float moveSpeed;

    [SerializeField]
    float chargeSpeed;

    [SerializeField]
    GameObject PlayerPosition;

    Vector3 TargetPosition;

    Rigidbody rb;

    bool isCharging;

    bool returnToPosition = false;

    public bool bossDestroyed = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        TargetPosition = PointB.position;
    }

    // Update is called once per frame
    public void Update()
    {

        //Intended Behavior : Wander between two positions. Charge at Player. Return to Position. Wander to TargetPosition. Charge. Repeat

        MoveToPoint();

    }


    void MoveToPoint()
    {
        // Move to Targetposition
        Vector3 goTo = GetNormalizedDistance(TargetPosition, transform.position);
        rb.velocity = goTo * moveSpeed;

        //when reach Targetposition, charge at Player and change Target Position
        if (CompareDistance(TargetPosition, transform.position) < 1)
        {
            isCharging = true;
            if (TargetPosition == PointB.position)
            {
                TargetPosition = PointA.position;
            }
            else TargetPosition = PointB.position;
        }

        //Behaviour while Charing
        if (isCharging)
        {
            StartCoroutine(WaitASecond());
        }
    }



    public void OnDestroy()
    {
        bossDestroyed = true;
    }


    IEnumerator WaitASecond()
    {


        rb.velocity = Vector3.zero;
        yield return new WaitForSeconds(1);


        if (PlayerPosition != null)
        {
            // Charge on Player
            rb.velocity = GetNormalizedDistance(PlayerPosition.transform.position, transform.position) * chargeSpeed;

            // Boss is on PlayerPosition
            if (CompareDistance(PlayerPosition.transform.position, transform.position) <= 1 || returnToPosition == true)
            {
                // bool ensures that the Boss stays in the loop, until he reached his previous Position from where he charged.
                returnToPosition = true;

                // If Target Position is A, Boss returns to B.
                if (CompareDistance(TargetPosition, PointA.position) <= 1)
                {

                    rb.velocity = GetNormalizedDistance(PointB.position, transform.position) * moveSpeed;
                    //When reaching B, break Loop and return to Behaviour Loop
                    if (CompareDistance(PointB.position, transform.position) <= 1)
                    {
                        isCharging = false;
                        returnToPosition = false;
                    }
                }
                
                // If Target Poisition is B, Boss moves to A
                else
                {
                    rb.velocity = GetNormalizedDistance(PointA.position, transform.position) * moveSpeed;

                    if (CompareDistance(PointA.position, transform.position) <= 1)
                    {
                        isCharging = false;
                        returnToPosition = false;
                    }
                }

            }

            
        }
 

    }
}
