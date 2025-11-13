using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Creature
{
    public int destinyTokenCount { get; private set; }

    [SerializeField]
    private DiceResultDisplayer diceResultDisplayer;
    [SerializeField]
    private Indicator indicator;
    public void RollButtonClicked() //굴리기 버튼 눌렀을 때 실행되는 것
    {
        // 아무때나 눌리는 거 방지할 플래그 필요
        RollDice();
        ApplyDice();
        //destinySelect() - 운명토큰 얼마나 써서 몇개 돌릴지 결정
        //ApplyJokbo(); - 족보 적용
        //Attack(); - 적 공격
        //Enemy.EnemyActionStart - 적 행동 시작
    }

    protected override void ApplyDice()
    {
        base.ApplyDice();

        destinyTokenCount += diceResults[6]; // 운명 토큰 획득
        indicator.IndicatorUpdate(this);
    }
    protected override void RollDice()
    {
        for (int i = 0; i  < totalDiceCount; i++)
        {
            base.RollDice();
        }
        Debug.Log("버튼 클릭");
        diceResultDisplayer.ResultUpdate(diceResults);
        

    }
    protected override Creature FindEnemy()
    {
        return GameObject.FindWithTag("Monster").GetComponent<Monster>();
    }
    protected override void EnemyActionStart()
    {

    }
    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        enemy = FindEnemy();
        destinyTokenCount = 0;
        Debug.Log(enemy);
    }
    void Start()
    {
        indicator.IndicatorUpdate(this);
        diceResultDisplayer.ResultUpdate(diceResults);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
