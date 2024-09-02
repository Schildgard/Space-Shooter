using TMPro;
using UnityEngine;

public class CreditUIText : MonoBehaviour
{
    //Displays and updates player Credits in Main Menu
    public TMP_Text CreditScore;
    private void Start()
    {
        CreditScore = GetComponent<TMP_Text>();
        UpdateCreditScore();
    }
    public void UpdateCreditScore()
    {
        CreditScore.text = PlayerInventoryData.Instance.Credits.ToString();
    }
}
