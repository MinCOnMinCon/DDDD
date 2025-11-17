using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Creature
{
    private int initDestinyTokenCount =  0;
    public int destinyTokenCount { get;  set; }
    public int attackCount { get;  set; }
    public int tempAttackCount { get;  set; }

    [SerializeField]
    private DiceResultDisplayer diceResultDisplayer;
    [SerializeField]
    private Indicator indicator;
    private HandsManager handsManager;
    public void RollButtonClicked() //굴리기 버튼 눌렀을 때 실행되는 것
    {
        // 아무때나 눌리는 거 방지할 플래그 필요
        RollDice();// 주사위 굴리기
        RollPenaltyDice();//- 패널티 주사위 굴리기
        ApplyDice(); // 주사위 결과보고 각 눈의 효과 적용
        //DestinySelect() //- 운명토큰 얼마나 써서 몇개 돌릴지 결정
        handsManager.ApplyAllHands(this, (Monster)enemy); //- 족보 적용, 서브는 applyDice 뒤에다 따로 하는 게 나을듯?
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
    
        diceResultDisplayer.ResultUpdate(diceResults);
    }
    protected override Creature FindEnemy()
    {
        return GameObject.FindWithTag("Monster").GetComponent<Monster>();
    }
    protected override void EnemyActionStart()
    {

    }
   
    public override void ResetCombatValues()
    {
        base.ResetCombatValues();
        destinyTokenCount = 0;
        
    }
    public override void ResetTurnValues()
    {
        base.ResetTurnValues();
        tempAttackCount = 0;
    }

    public void DestinySelect(int usingDestinyTokenCount)
    {
        for (int i = 0; i < usingDestinyTokenCount; i++)
        {
            base.RollDice();
        }

        diceResultDisplayer.ResultUpdate(diceResults);
    }
    protected override void Awake()
    {
        base.Awake();
        enemy = FindEnemy();
        destinyTokenCount = 0;
        handsManager = GetComponent<HandsManager>();
        Debug.Log(enemy);
    }

    void Start() // awake로 하면 업데이트 순서 꼬여서 start에 있는 애들임
    {
        indicator.IndicatorUpdate(this);
        diceResultDisplayer.ResultUpdate(diceResults);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
