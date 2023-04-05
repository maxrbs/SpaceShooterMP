using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class HUDUpdater : NetworkBehaviour
{
    [SerializeField] private Text coinsCounter;
    [SerializeField] private Text playersCountText;
    [SerializeField] private Button hostButton;
    [SerializeField] private Button clientButton;

    private NetworkVariable<int> playersCount = new NetworkVariable<int>(0, NetworkVariableReadPermission.Everyone);

    public void SetCoinsCount(int count)
    {
        coinsCounter.text = count.ToString();
    }

    private void Update()
    {
        playersCountText.text = "Players:" + playersCount.Value.ToString();

        if (!IsServer) return;
        playersCount.Value = NetworkManager.Singleton.ConnectedClients.Count;

    }

    public void Awake()
    {
        //hostButton.onClick.AddListener(() => { NetworkManager.Singleton.StartHost(); });
        //clientButton.onClick.AddListener(() => { NetworkManager.Singleton.StartClient(); });

    }    

}
