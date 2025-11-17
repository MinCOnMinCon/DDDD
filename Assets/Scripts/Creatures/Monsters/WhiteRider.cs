using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteRider : Monster
{
    public override void ActionStart()
    {
        string log = null;
        switch (patternNum) 
        {
            case 0:
                enemy.penaltyDiceCount += 1;
                attackValue = 10;
                defenseValue = 10;
                log += $"{this.name}는 쥐들을 풀려한다..";
                break;
            case 1:
                enemy.penaltyDiceCount += 2;
                attackValue = 8;
                log += $"{this.name}쪽으로 초록색 안개가 모인다..";
                break;
            case 2:
                enemy.defenseValue -= 10;
                attackValue = 14;
                log += $"{this.name}는 시커먼 촉을 가진 화살을 들었다..";
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
        name = "\"역병\"";
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
