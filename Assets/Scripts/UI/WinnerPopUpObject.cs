using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinnerPopUpObject : PopUpObject
{
    [SerializeField] private Text winnerNameText; 
    [SerializeField] private Text winnerCoinsText;

    public void UpdateTextFields(string winnerName, int coinsCount)
    {
        winnerNameText.text = winnerName;
        winnerCoinsText.text = coinsCount.ToString();
    }


}
