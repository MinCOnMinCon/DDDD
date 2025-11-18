using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Creature
{
    protected int patternNum;
 
    protected override Creature FindEnemy()
    {
        return GameObject.FindWithTag("Player").GetComponent<Player>();
        
    }

    public override void ActionStart()
    {
        
    }
    protected override void Died() 
    {
        enemy.ResetCombatValues();
        // 보상 주기
        // 사망 멘트 출력
        // 위 두 함수 코루틴으로 실행
        MonsterManager.instance.DieMonster();
        Destroy(gameObject);
    }
    protected override void Awake()
    {
        base.Awake();
        
        patternNum = 0;
    }

    void Start()
    {
        UpdateEnemy();
        Debug.Log(enemy.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
