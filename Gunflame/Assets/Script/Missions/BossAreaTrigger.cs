using UnityEngine;

public class BossAreaTrigger : MonoBehaviour
{
    //Boss spawns when player enters the room

    [SerializeField] private GameObject Boss;
    [SerializeField] private Transform BossTransform;
    [SerializeField] private Transform PlayerTransform;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            Boss.SetActive(true);
        }
    }

}
