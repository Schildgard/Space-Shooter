using UnityEngine;

public class Mission01 : MonoBehaviour
{
    [SerializeField] private GameObject Boss;
    private BossCharger bossScript;

    void Start()
    {
        // Mission01 contains a Boss. Its Charger Scripts contains the Bool, which says if he has been defeated or not
        if (Boss != null)
        {
            bossScript = Boss.GetComponent<BossCharger>();
        }
    }

    // Area Collider checks if Missionobjectives has been achieved. Rewards with credits and sends player back to titlescreen
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3 && bossScript.bossDestroyed == true)
        {
            PlayerInventoryData.Instance.Credits += 50;
            GameManager.instance.sceneloader.LoadTitleScreen();
        }
    }
}
