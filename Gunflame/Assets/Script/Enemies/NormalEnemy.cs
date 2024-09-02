using UnityEngine;

public class NormalEnemy : EnemyScript
{
    //This Enemy only moves towards the Player
    private GameObject player;
    private Rigidbody rb;
    [SerializeField]private float moveSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    public void Update()
    {
        if (player != null) 
        {
        Vector3 Target = GetNormalizedDistance(player.transform.position, transform.position);
        rb.velocity = Target * moveSpeed;
        }
    }
}
