using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorComponent : MonoBehaviour
{
    [SerializeField] private int coinsCount;

    public void AddCoins(int count)
    {
        coinsCount += Mathf.Abs(count);
    }

    public void RemoveCoins(int count)
    {
        coinsCount -= Mathf.Abs(count);

        if (coinsCount < 0)
            coinsCount = 0;
    }
}
