using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Creature
{
    protected override Creature FindEnemy()
    {
        return GameObject.FindWithTag("Player").GetComponent<Player>();
    }
    protected override void EnemyActionStart()
    {

    }

    private void Awake()
    {
        base.Awake();
        FindEnemy();
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
