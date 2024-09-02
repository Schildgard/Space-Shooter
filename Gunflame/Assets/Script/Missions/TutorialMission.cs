using System.Collections;
using UnityEngine;

public class TutorialMission : MonoBehaviour
{
    [SerializeField] private GameObject EnemyWave;
    [SerializeField] private GameObject MissionsolvedText;
    [SerializeField] private GameObject Player;

    private WeaponHandler handler; //Weaponhandler rquips the player with a second Weapon for Weapon2Test Mission and removes it after tutorial.
    private bool tutorialDone;

    //Task 1
    [SerializeField] private GameObject MoveMission1Message;
    private bool movedForward;
    private bool movedBackward;
    private bool movedUp;
    private bool movedDown;
    private bool movementTestSolved;

    // Task 2
    [SerializeField] private GameObject BoostTestMessage;
    private bool boostTestSolved;

    // Task 3
    [SerializeField] private GameObject FireTest1Message;
    private bool weapon1TestSolved;
    // Task 4
    [SerializeField] private GameObject FireTest2Message;
    private bool weapon2TestSolved;
    //Task 5
    [SerializeField] private GameObject CombatTestTextMessage;
    private bool enemiesSpawned;

    void Start()
    {
        handler = Player.GetComponent<WeaponHandler>();
    }

    void Update()
    {
        MovementTest();

        if (movementTestSolved)
        {
            DashTest();
        }

        if (boostTestSolved)
        {
            Weapon1Test();
        }
        if (weapon1TestSolved)
        {
            Weapon2Test();
        }

        if (weapon2TestSolved)
        {
            CombatTest();
        }

        if (EnemyWave.transform.childCount <=0)
        {
            tutorialDone = true;
        }
        if (tutorialDone)
        {
            GoBackToTitleScreen();
        }
    }


    void MovementTest()
    {
        if (!movementTestSolved)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                movedUp = true;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                movedDown = true;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                movedForward = true;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                movedBackward = true;
            }
            if (movedBackward && movedDown && movedUp && movedForward)
            {
                movementTestSolved = true;
                MoveMission1Message.SetActive(false);
                BoostTestMessage.SetActive(true);
            }
        }
    }



    void DashTest()
    {
        if (!boostTestSolved)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                boostTestSolved = true;
                BoostTestMessage.SetActive(false);
                FireTest1Message.SetActive(true);
            }
        }
    }

    void Weapon1Test()
    {
        if (!weapon1TestSolved)
        {
            if (Input.GetMouseButtonDown(0))
            {
                FireTest1Message.SetActive(false);
                weapon1TestSolved = true;
                FireTest2Message.SetActive(true);
            }
        }
    }
    void Weapon2Test()
    {
        if (!weapon2TestSolved)
        {
            if (Input.GetMouseButtonDown(1))
            {
                PlayerInventoryData.Instance.AquiredEquipment.Add(PlayerInventoryData.Instance.weapons[1]);
                handler.Weapon2 = PlayerInventoryData.Instance.weapons[1];
                handler.EquipWeapon2();
                FireTest2Message.SetActive(false);
                weapon2TestSolved = true;
                CombatTestTextMessage.SetActive(true);
            }
        }
    }

    void CombatTest()
    {
        if (!enemiesSpawned)
        {
            EnemyWave.SetActive(true);
            enemiesSpawned = true;
        }
    }

    void GoBackToTitleScreen()
    {
        if (tutorialDone)
        {
            CombatTestTextMessage.SetActive(false);
            MissionsolvedText.SetActive(true);
            StartCoroutine(WaitAndReturn());
        }
    }

    IEnumerator WaitAndReturn()
    {
        yield return new WaitForSeconds(5);

        //Remove Tutorial MachineGun from Equipment List
        PlayerInventoryData.Instance.AquiredEquipment.Remove(PlayerInventoryData.Instance.weapons[1]);
        // If MachineGun is not in Inventory, unequip MachineGun
        if (PlayerInventoryData.Instance.AquiredEquipment.Contains(PlayerInventoryData.Instance.weapons[1]) == false)
        {
            handler.Weapon2 = null;
        }

        PlayerInventoryData.Instance.Credits += 20;
        GameManager.instance.sceneloader.LoadTitleScreen();
    }
}
