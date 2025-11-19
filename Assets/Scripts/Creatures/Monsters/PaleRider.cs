
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaleRider : Monster
{
    public override void ActionStart()
    {
        string log = null;
        switch (patternNum) 
        {
            
            case 0:
                enemy.health -= 5;
                defenseValue = 8;
                log += $"{this.name}이 손을 내리긋자, 묘비가 떨어진다.. | 체력 -5\n" +
                    $"{this.name}의 방어력 : {defenseValue}";
                break;
            case 1:
                enemy.penaltyDiceCount +=1;
                enemy.tempDiceCount -= 1;
                log += $"{this.name}가 낫을 꽂자, 당신은 쇠약해진다.. | 주사위 -1, 패널티 주사위 +1\n";
                    
                break;
            case 2:
                attackValue = 30;
                log += $"{this.name}가 낫을 휘둘러 당신의 목을 수확하려 한다..\n" +
                    $"{this.name}의 공격력 : {attackValue}";
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
        LogEvent.onLog?.Invoke(log); 
    }
    
    // Start is called before the firs음t frame update
    protected override void Awake()
    {
        base.Awake();
        name = "\"죽음\"";
    }

  

    // Update is called once per frame
    void Update()
    {
        
    }
}
