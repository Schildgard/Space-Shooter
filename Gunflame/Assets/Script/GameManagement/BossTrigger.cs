using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    // Trigger which spawns the boss to appear when player enters
    [SerializeField] private GameObject boss;

    private void OnTriggerEnter(Collider _other)
    {
        if(_other.gameObject.layer == 3 && boss.activeSelf == false)
        {
            Debug.Log("Trigger Boss");
            boss.SetActive(true);
        }
    }
}
