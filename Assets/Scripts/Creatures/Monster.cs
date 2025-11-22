using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Creature
{
    protected int patternNum;
    public static Action onMonsterDied;
    protected override Creature FindEnemy()
    {
        return GameObject.FindWithTag("Player").GetComponent<Player>();
        
    }

    public override void ActionStart()
    {
        
    }
    IEnumerator DieRoutine()
    {
        enemy.ResetCombatValues();
        onMonsterDied?.Invoke();
        yield return new WaitForSeconds(2f);
        MonsterManager.instance.DieMonster();
        Destroy(gameObject);
    }
    protected override void Died() 
    {
        StartCoroutine(DieRoutine());
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
