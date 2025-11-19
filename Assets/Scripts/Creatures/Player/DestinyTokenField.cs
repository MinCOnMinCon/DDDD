using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DestinyTokenField : MonoBehaviour
{
   
    private TMP_InputField destinyTokenField;
    private Player player;

    public void ConnectDestinyTokenField(Player player)
    {
        destinyTokenField = GameObject.Find("DestinyTokenField").GetComponent<TMP_InputField>();
        destinyTokenField.onEndEdit.AddListener(EnteredDestinyToken);
        this.player = player;   
    }
    public void EnteredDestinyToken(string num)
    {
        bool isUsedDestiny = int.TryParse(num, out int value);
        player.DestinySelect(value);
    }
}
