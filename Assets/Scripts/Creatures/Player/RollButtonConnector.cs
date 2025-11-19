using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollButtonConnector : MonoBehaviour
{

    private Button rollButton;
    
    public void ConnectRollButton(Player player)
    {
   
        rollButton = GameObject.Find("DiceRollButton").GetComponent<Button>();
        rollButton.onClick.AddListener(player.RollButtonClicked);
    }
   
  
    
}
