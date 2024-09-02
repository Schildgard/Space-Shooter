using UnityEngine;

public class BuyButtonScript : MonoBehaviour
{
    public int indexValue;
    public CreditUIText creditUI;

    private void Awake()
    {
        creditUI = GameObject.Find("Credits Amount").GetComponent<CreditUIText>();
    }
    public void BuyWeapon()
    {
        // If Player has enough credits: buy weapon
        if (PlayerInventoryData.Instance.Credits >= PlayerInventoryData.Instance.weapons[indexValue].worth)
        {
            PlayerInventoryData.Instance.Credits -= PlayerInventoryData.Instance.weapons[indexValue].worth;
            PlayerInventoryData.Instance.AquiredEquipment.Add(PlayerInventoryData.Instance.weapons[indexValue]);
            creditUI.UpdateCreditScore();
            AudioManager.instance.SFX[4].Source.Play();
        }
        else
            Debug.Log("Not Enough Credits");
    }
}
