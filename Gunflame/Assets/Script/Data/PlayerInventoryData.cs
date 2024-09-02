using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryData : MonoBehaviour
{
    //This scripts purpose is to manage player relevant data like credits or inventory
    public static PlayerInventoryData Instance;
    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }
        DontDestroyOnLoad(gameObject);
    }

    public int Credits;
    public List<Weapon> AquiredEquipment;
    public List<Weapon> EquipSlot;
    public List<Weapon> weapons;

    int Weapon1Index;
    int Weapon2Index;

    public bool creditNotificaitonGiven;

    public void AssignWeaponToSlot1(int _index)
    {
        EquipSlot[0] = AquiredEquipment[_index]; 
    }
    public void AssignWeaponToSlot2(int _index)
    {
        EquipSlot[1] = AquiredEquipment[_index];
    }
 
}
