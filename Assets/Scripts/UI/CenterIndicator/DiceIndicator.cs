using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DiceIndicator : MonoBehaviour
{
    private TMPro.TextMeshProUGUI totalDiceText;
    private TMPro.TextMeshProUGUI tempDiceText;

    // Start is called before the first frame update

    public void DiceUpdate(int totalDiceCount, int tempDiceCount)
    {
        totalDiceText.text = totalDiceCount.ToString();
        tempDiceText.text = tempDiceCount.ToString();
    }
    void Awake()
    {
        var arr = GetComponentsInChildren<TMPro.TextMeshProUGUI>();
        totalDiceText = arr[1];
        tempDiceText = arr[3];

    }

    
}
