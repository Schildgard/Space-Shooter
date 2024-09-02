using System.Collections.Generic;
using UnityEngine;

public class InventoryButtonScript : MonoBehaviour
{
    //This Script represents a Button that is connected to a weapon reference.

    public int IndexValue; //Represents weapon type. Currently there are two weapons in the Game so the Indexvalue is eiter 0 or 1.
    public int CopyNumber; // Copy Number works more like an Index. If the player has multiple Objects of the same weapon this value represents its instance.
    public CreditUIText CreditsScript;
    public Weapon RelatedWeapon;


    private void Awake()
    {
        CreditsScript = GameObject.Find("Credits Amount").GetComponent<CreditUIText>();
        RelatedWeapon = PlayerInventoryData.Instance.AquiredEquipment[IndexValue];
    }

    private void Update()
    {
        // Check if the related Weapon to this button exists in the List - if not: destroy the button
        if (PlayerInventoryData.Instance.AquiredEquipment.Contains(RelatedWeapon) == false || (CopyNumber > CountListWeapon(PlayerInventoryData.Instance.AquiredEquipment))) //vll. stattedessen in eine else i
        {
            if (PlayerInventoryData.Instance.EquipSlot[0] == RelatedWeapon)
            {
                PlayerInventoryData.Instance.EquipSlot[0] = null;
            }
            else if (PlayerInventoryData.Instance.EquipSlot[1] == RelatedWeapon)
            {
                PlayerInventoryData.Instance.EquipSlot[1] = null;
            }
            GetComponentInParent<WorkShopMenuButton>().InventoryCount--;
            Destroy(gameObject);
            GetComponentInParent<WorkShopMenuButton>().buttonlist.RemoveAt(CopyNumber-1);
        }

        //check if WeaponSlot1 and WeaponSlot2 have attached the same Weapon and check if the List has more than one objects of that Weapon
        //if not: Deattach a Weapon
        if (PlayerInventoryData.Instance.EquipSlot[0] == PlayerInventoryData.Instance.EquipSlot[1] && PlayerInventoryData.Instance.EquipSlot[0] != null) 
        {
            if (CountListWeapon(PlayerInventoryData.Instance.AquiredEquipment)<2)
            {
                PlayerInventoryData.Instance.EquipSlot[1] = null;
            }
        }
    }

    public void AssignWeaponToSlot1()
    {
        PlayerInventoryData.Instance.EquipSlot[0] = PlayerInventoryData.Instance.AquiredEquipment[IndexValue];
        AudioManager.instance.SFX[4].Source.Play();
    }
    public void AssignWeaponToSlot2()
    {
        PlayerInventoryData.Instance.EquipSlot[1] = PlayerInventoryData.Instance.AquiredEquipment[IndexValue];
        AudioManager.instance.SFX[4].Source.Play();
    }


    public void SellWeapon()
    {
        PlayerInventoryData.Instance.Credits += PlayerInventoryData.Instance.AquiredEquipment[IndexValue].worth;
        CreditsScript.UpdateCreditScore();
        PlayerInventoryData.Instance.AquiredEquipment.Remove(PlayerInventoryData.Instance.AquiredEquipment[IndexValue]);
        AudioManager.instance.SFX[4].Source.Play();
    }

    public int CountListWeapon(List<Weapon> _list) 
    {
        int count = 0;
        for (int i = 0; i < _list.Count; i++)
        {
            if (_list[i] == RelatedWeapon)
            {
                count++;
            }
        }
        return count;
    }
}
