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
        ;
    }
    protected override void Awake()
    {
        base.Awake();
        enemy = FindEnemy();
        patternNum = 0;
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
