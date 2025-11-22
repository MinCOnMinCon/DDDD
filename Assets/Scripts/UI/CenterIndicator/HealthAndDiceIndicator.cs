using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthAndDiceIndicator : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI totalDiceText;
    [SerializeField]
    private TMPro.TextMeshProUGUI tempDiceText;
    [SerializeField]
    private TMPro.TextMeshProUGUI healthText;


    public void HealthUpdate(int health)
    {
        healthText.text = health.ToString();
    }
    public void DiceUpdate(int totalDiceCount, int tempDiceCount)
    {
        totalDiceText.text = totalDiceCount.ToString();
        tempDiceText.text = tempDiceCount.ToString();
    }
 
  
}

