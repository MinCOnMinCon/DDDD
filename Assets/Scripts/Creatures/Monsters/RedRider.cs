using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedRider : Monster
{
    public override void ActionStart()
    {
        string log = null;
        switch (patternNum) 
        {
            
            case 0:
                attackValue = 20;

                log += $"{this.name}은 대검을 크게 휘두른다.. \n" +
                    $"{this.name}의 공격력 : {attackValue}";
                break;
            case 1:
                enemy.tempDiceCount -= 1;
                attackValue = 10;
                log += $"{this.name}의 말이 당신을 향해 돌진한다.. | 주사위 -1\n" +
                    $"{this.name}의 공격력 : {attackValue}";
                break;
            case 2:
                enemy.health -= 10;
                attackValue = 15;
                log += $"{this.name}은 당신의 몸을 난자한다.. | 체력 -10\n" +
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
    
    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        name = "\"전쟁\"";
    }

  

    // Update is called once per frame
    void Update()
    {
        
    }
}
