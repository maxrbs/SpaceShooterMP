using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class CollectorComponent : MonoBehaviour
{
    [SerializeField] private int coinsCount;

    public UnityEvent OnCoinCollect;

    public void AddCoins(int count)
    {
        coinsCount += Mathf.Abs(count);

        OnCoinCollect.Invoke();
    }

    public void RemoveCoins(int count)
    {
        coinsCount -= Mathf.Abs(count);

        if (coinsCount < 0)
            coinsCount = 0;
    }
}
