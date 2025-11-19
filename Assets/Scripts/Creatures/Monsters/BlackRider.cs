
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackRider : Monster
{
    public override void ActionStart()
    {
        string log = null;
        switch (patternNum) 
        {
            
            case 0:
                enemy.tempDiceCount -= 2;
                attackValue = 7;
                defenseValue = 7;
                log += $"{this.name}은 저울을 기울인다.. | 주사위 -2\n" +
                    $"{this.name}의 공격력 : {attackValue} | {this.name}의 방어력 : {defenseValue}";
                break;
            case 1:
                enemy.defenseValue -= 15;
                attackValue = 10;
                log += $"{this.name}의 저울이 왼쪽으로 기운다.. | 방어 수치 -15 \n" +
                    $"{this.name}의 공격력 : {attackValue}";
                break;
            case 2:
               enemy.attackValue -= 15;
                defenseValue = 10;
                log += $"{this.name}의 저울이 오른쪽으로 기운다.. | 공격 수치 -15\n" +
                    $"{this.name}의 방어력 : {defenseValue}";
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
        name = "\"기근\"";
    }

  

    // Update is called once per frame
    void Update()
    {
        
    }
}
