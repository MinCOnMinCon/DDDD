using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DestinyAndPenaltyIndicator : MonoBehaviour
{
    private TMPro.TextMeshProUGUI[] DestinyAndPenaltyArr;
    // Start is called before the first frame update
    public void DestinyAndPenaltyUpdate(int destinyTokenNum, int penaltyDiceNum)
    {
        DestinyAndPenaltyArr[0].text = destinyTokenNum.ToString();
        DestinyAndPenaltyArr[1].text = penaltyDiceNum.ToString();
    }
    void Awake()
    {
        DestinyAndPenaltyArr = new TMPro.TextMeshProUGUI[2];
        DestinyAndPenaltyArr[0] = transform.Find("DestinyTokenText").GetComponent<TextMeshProUGUI>();
        DestinyAndPenaltyArr[1] = transform.Find("PenaltyDiceText").GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
