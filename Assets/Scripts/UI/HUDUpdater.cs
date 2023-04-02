using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDUpdater : MonoBehaviour
{
    [SerializeField] private Text coinsCounter;

    public void SetCoinsCount(int count)
    {
        coinsCounter.text = count.ToString();
    }
}
