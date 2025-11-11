using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceResultDisplayer : MonoBehaviour
{
   
    [SerializeField]
    private TMPro.TextMeshProUGUI[] diceCountText = new TMPro.TextMeshProUGUI[7];
    
    public void ResultUpdate(int[] results)
    {
       
        for (int i = 1; i < 7; i++)
        {
            diceCountText[i].text = results[i].ToString();
        }
    }
    
}
