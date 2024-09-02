using UnityEngine;

public class CreditNotification : MonoBehaviour
{
    /*The Idea of that script was to show a Message to the player after he finished the tutorial and instruct him to spend the
     credits he earned to buy a new Weapon. However this implementation does not make much sense. With given time I should implement
     event system to trigger the message instead.*/

    [SerializeField] private GameObject titleMenu;
    [SerializeField] private GameObject missionMenu;
    [SerializeField] private GameObject notification;

    void Update()
    {
        // Condition is set to 20 as a quit Fix so the Message only shows up after finishing the tutorial once,
        // but not when the player starts the game and immediatly sells his weapon
        if (PlayerInventoryData.Instance.Credits == 20 && PlayerInventoryData.Instance.creditNotificaitonGiven == false)
        {
            titleMenu.SetActive(false);
            missionMenu.SetActive(true);
            notification.SetActive(true);

            PlayerInventoryData.Instance.creditNotificaitonGiven = true;
        }

    }
}
