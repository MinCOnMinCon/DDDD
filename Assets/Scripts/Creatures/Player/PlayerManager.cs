using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    [SerializeField]
    private UIManager uiManager;

    [SerializeField]
    private GameObject playerPrefab;
    private GameObject player;
    private void Awake()
    {
        instance = this;
    }

    public void SpawnPlayer()
    {
        player = Instantiate(playerPrefab);
        player.GetComponent<Player>().ConnectUI();
    }
    public void UpdatePlayer()
    {
        Player temp = player.GetComponent<Player>();
        
        temp.UpdateEnemy(); 
        temp.UpdateIndicator();
    }
    public void DestroyPlayer()
    {
        player.GetComponent<HandsManager>().DeleteAllHands();
        Destroy(player);
    }
    public bool isPlayerExisted()
    {
        return player != null;
    }
    
    public void DiePlayer()
    {
        uiManager.GameoverConversion(true);
    }


}
