using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteRider : Monster
{
    public override void ActionStart()
    {
        Debug.Log("AA");
        switch (patternNum) 
        {
            case 0:
                enemy.penaltyDiceCount += 1;
                attackValue = 10;
                defenseValue = 10;
                Debug.Log("----패턴 1----");
                break;
            case 1:
                enemy.penaltyDiceCount += 2;
                attackValue = 8;
                Debug.Log("----패턴 2----");
                break;
            case 2:
                enemy.defenseValue -= 10;
                attackValue = 14;
                Debug.Log("----패턴 3----");
                break;
        }
        if(patternNum > 1)
        {
            patternNum = 0;
        }
        else
        {
            patternNum++;
        }
            Debug.Log($"{patternNum}.");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
