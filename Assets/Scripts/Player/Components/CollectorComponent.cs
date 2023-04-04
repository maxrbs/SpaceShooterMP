using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;

public class CollectorComponent : NetworkBehaviour
{
    [SerializeField] private NetworkVariable<int> coinsCount = new NetworkVariable<int>(
            0, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Server);

    public UnityEvent OnCoinCollect;

    private HUDUpdater hudUpdater;

    private void Start()
    {
        hudUpdater = FindObjectOfType<HUDUpdater>();
        OnCoinCollect.AddListener(UpdateCoinsCountOnUI);
    }

    public void AddCoins(int count)
    {
        coinsCount.Value += Mathf.Abs(count);

        OnCoinCollect.Invoke();
    }

    public void RemoveCoins(int count)
    {
        coinsCount.Value -= Mathf.Abs(count);

        if (coinsCount.Value < 0)
            coinsCount.Value = 0;
    }

    public void UpdateCoinsCountOnUI()
    {
        hudUpdater.SetCoinsCount(coinsCount.Value);
    }

    public int GetCoinsCount()
    {
        return coinsCount.Value;
    }
}
