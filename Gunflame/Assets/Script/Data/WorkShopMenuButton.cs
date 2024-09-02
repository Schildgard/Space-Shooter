using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class WorkShopMenuButton : MonoBehaviour
{
    [SerializeField] private GameObject scrollableObject;
    [SerializeField] private GameObject buttonToHide; //The Button which is placed below will hide while this button is activated

    [SerializeField] private List<List<Weapon>> list;
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private GameObject inventoryPanel; // Panel Child of Content Object
    private int shopItemCount = 0;

    public List<Weapon> buttonlist = new List<Weapon> { };
    public int InventoryCount = 0;

    public void OpenWeaponShopList()
    {
        if (shopItemCount < PlayerInventoryData.Instance.weapons.Count)
        {
            for (int i = 0; i < PlayerInventoryData.Instance.weapons.Count; i++)
            {
                 // Instantiate an Interactable Button for every Weapon Aquired
                GameObject button = Instantiate(buttonPrefab, inventoryPanel.transform);
                button.GetComponentInChildren<TMP_Text>().text = PlayerInventoryData.Instance.weapons[i].name + " " + PlayerInventoryData.Instance.weapons[i].worth + "C";
                button.GetComponent<BuyButtonScript>().indexValue = i;
                shopItemCount++;
            }
        }
        scrollableObject.SetActive(!scrollableObject.activeSelf);
        if (buttonToHide != null)
        {
            buttonToHide.SetActive(!buttonToHide.activeSelf);
        }
    }

    public void OpenAquiredWeaponList()
    {
        if (InventoryCount < PlayerInventoryData.Instance.AquiredEquipment.Count)
        {
            for (int i = 0; i < PlayerInventoryData.Instance.AquiredEquipment.Count; i++)
            {
                 // Instantiate an Interactable Button for every Weapon Aquired
                GameObject button = Instantiate(buttonPrefab, inventoryPanel.transform);
                button.GetComponentInChildren<TMP_Text>().text = PlayerInventoryData.Instance.AquiredEquipment[i].name + " " + PlayerInventoryData.Instance.weapons[i].worth + "C";
                button.GetComponent<InventoryButtonScript>().IndexValue = i;
                InventoryCount++;

                //Buttonlist holds amounts of weapons in it
                buttonlist.Add(PlayerInventoryData.Instance.AquiredEquipment[i]);
                //Count How often this exact weapon is in the buttonlist, and count the button copyNumber to it.
                for (int j = 0; j < buttonlist.Count; j++)
                {
                    if (buttonlist[j] == PlayerInventoryData.Instance.AquiredEquipment[i])
                    {
                        button.GetComponent<InventoryButtonScript>().CopyNumber++;
                    }
                }
            }
        }
        scrollableObject.SetActive(!scrollableObject.activeSelf);
        if (buttonToHide != null)
        {
            buttonToHide.SetActive(!buttonToHide.activeSelf);
        }
    }
}
