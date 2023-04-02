using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UI;

public class CollectorComponent : MonoBehaviour
{
    [SerializeField] private int coinsCount;

    public UnityEvent OnCoinCollect;

    private HUDUpdater hudUpdater;

    private void Start()
    {
        hudUpdater = FindObjectOfType<HUDUpdater>();
        OnCoinCollect.AddListener(UpdateCoinsCountOnUI);
    }

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

    public void UpdateCoinsCountOnUI()
    {
        hudUpdater.SetCoinsCount(coinsCount);
    }
}
