using System.Collections;
using System.Collections.Generic;
using System.Threading;
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

   
    IEnumerator MyRoutine()
    {
        // 아무때나 눌리는 거 방지할 플래그 필요
        enemy.ActionStart(); //- 적의 행동 보여줌. 
        yield return new WaitForSeconds(2f);
        RollDice();// 주사위 굴리기
        RollPenaltyDice();//- 패널티 주사위 굴리기
        handsManager.ApplySubHands(this, (Monster)enemy); // 서브 족보 적용
        yield return new WaitForSeconds(2f);
        ApplyDice(); // 주사위 결과보고 각 눈의 효과 적용
        diceResultDisplayer.ResultUpdate(diceResults); // 주사위 결과를 UI에 업데이트
        yield return new WaitForSeconds(2f);
        //DestinySelect() //- 운명토큰 얼마나 써서 몇개 돌릴지 결정
        handsManager.ApplyFourHands(this, (Monster)enemy); //- 서브 족보외 족보들 적용, 

        Attack(); //- 적을 공격
        enemy.Attack(); // - 적의 공격
        indicator.IndicatorUpdate(this);
        ResetTurnValues(); // 턴에 초기화해야 할 값 초기화 
    }
    
    public void RollButtonClicked() //굴리기 버튼 눌렀을 때 실행되는 것
    {
        StartCoroutine(MyRoutine());

    }
    
    protected override void ApplyDice()
    {
        LogEvent.onLog?.Invoke("주사위의 결과는...");
        LogEvent.onLog?.Invoke($"주사위1:{diceResults[1]}개 | 주사위2:{diceResults[2]}개 | 주사위3:{diceResults[3]}개 |  " +
           $"주사위4:{diceResults[4]}개 | 주사위5:{diceResults[5]}개 | 주사위6:{diceResults[6]}개");
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
        LogEvent.onLog?.Invoke("당신은 주사위를 굴렸다...");
        



    }
    protected override Creature FindEnemy()
    {
        return GameObject.FindWithTag("Monster").GetComponent<Monster>();
    }
    public override void ActionStart()
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
        handsManager.ResetAllHands();
        Debug.Log("플레이어 턴 수치 초기화");
    }

    public void DestinySelect(int usingDestinyTokenCount)
    {
        for (int i = 0; i < usingDestinyTokenCount; i++)
        {
            base.RollDice();
        }
        destinyTokenCount -= usingDestinyTokenCount;
        diceResultDisplayer.ResultUpdate(diceResults);
    }
    protected override void Awake()
    {
        base.Awake();
        enemy = FindEnemy();
        destinyTokenCount = 0;
        handsManager = GetComponent<HandsManager>();
        name = "당신";
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
