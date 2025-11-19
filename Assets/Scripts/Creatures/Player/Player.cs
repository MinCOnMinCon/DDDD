using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

public class Player : Creature
{
    private int initDestinyTokenCount =  0;
    
    public int destinyTokenCount { get;  set; }
    public int attackCount { get;  set; }
    public int tempAttackCount { get;  set; }

    
    private DiceResultDisplayer diceResultDisplayer;
    
    private Indicator indicator;
    private HandsManager handsManager;
    private RollButtonConnector rollButtonConnector;
    private DestinyTokenField destinyTokenField;

    private bool rollButtonFlag = false;
    private bool destinyTokenFlag = false;

   
    IEnumerator MyRoutine()
    {
        rollButtonFlag = true;
        enemy.ActionStart(); //- 적의 행동 보여줌. 
        yield return new WaitForSeconds(2f);
        RollDice();// 주사위 굴리기
        RollPenaltyDice();//- 패널티 주사위 굴리기
        handsManager.ApplySubHands(this, (Monster)enemy); // 서브 족보 적용
        yield return new WaitForSeconds(2f);
        ApplyDice(); // 주사위 결과보고 각 눈의 효과 적용
        diceResultDisplayer.ResultUpdate(diceResults); // 주사위 결과를 UI에 업데이트
        LogEvent.onLog?.Invoke("당신은 사용할 운명 토큰의 수를 써야 한다.\n" +
            "(사용할 토큰이 없다면 Enter를 누르세요)");
        yield return new WaitUntil(() => destinyTokenFlag);
        handsManager.ApplyFourHands(this, (Monster)enemy); //- 서브 족보외 족보들 적용, 
        yield return new WaitForSeconds(1f);
        UpdateIndicator();
        Attack(); //- 적을 공격
        yield return new WaitForSeconds(1f);
        enemy.Attack(); // - 적의 공격
        
        ResetTurnValues(); // 턴에 초기화해야 할 값 초기화 
        UpdateIndicator();

        
    }
    
    public void RollButtonClicked() //굴리기 버튼 눌렀을 때 실행되는 것
    {
        if (!rollButtonFlag)
        {
            StartCoroutine(MyRoutine());
        }


    }
    
    protected override void ApplyDice()
    {
        base.ApplyDice();
        
        

        destinyTokenCount += diceResults[6]; // 운명 토큰 획득
        LogEvent.onLog?.Invoke("주사위의 결과는...");
        LogEvent.onLog?.Invoke($"주사위1:{diceResults[1]}개 | 주사위2:{diceResults[2]}개 | 주사위3:{diceResults[3]}개 |  " +
           $"주사위4:{diceResults[4]}개 | 주사위5:{diceResults[5]}개 | 주사위6:{diceResults[6]}개");
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
        ResetTurnValues();
        destinyTokenCount = initDestinyTokenCount;
        
    }
    public override void ResetTurnValues()
    {
        base.ResetTurnValues();
        rollButtonFlag = false;
        destinyTokenFlag = false;
        tempAttackCount = 0;
        handsManager.ResetAllHands();
        Debug.Log("플레이어 턴 수치 초기화");
    }
    public override void Attack()
    {
        LogEvent.onLog?.Invoke($"당신은 {attackCount + tempAttackCount}번의 공격을 시도한다.");
        for(int i = 0; i < attackCount+tempAttackCount; i++)
        {
            base.Attack();
        }
    }

    public void DestinySelect(int usingDestinyTokenCount)
    {
        if(usingDestinyTokenCount <= 0)
        {
            destinyTokenFlag = true;
            return;
        }
        else if(usingDestinyTokenCount > destinyTokenCount)
        {
            return;
        }
        else
        {
            
            LogEvent.onLog?.Invoke($"당신은 {usingDestinyTokenCount}개 만큼 주사위를 더 돌린다.");
            int[] tempDiceResults = diceResults.ToArray();
            for (int i = 0; i < usingDestinyTokenCount; i++)
            {
                
                base.RollDice();
            }
            ApplyDice();
            destinyTokenCount -= usingDestinyTokenCount;
            UpdateIndicator();
            destinyTokenFlag = true;
        }
    }
    protected override void Awake()
    {
        base.Awake();
        
        destinyTokenCount = initDestinyTokenCount;
        attackCount = 1;
        tempAttackCount = 0;
        handsManager = GetComponent<HandsManager>();
        rollButtonConnector = GetComponent<RollButtonConnector>();
        destinyTokenField = GetComponent<DestinyTokenField>();
        name = "당신";
        GameObject.Find("HandsUI").GetComponent<HandsUIManager>().SetHandsManager(handsManager);


    }
    protected override void Died()
    {
        handsManager.DeleteAllHands();
        PlayerManager.instance.DiePlayer();
        
    }
    
    public void UpdateIndicator()
    {
        indicator.IndicatorUpdate(this);
        diceResultDisplayer.ResultUpdate(diceResults);
    }
    public void ConnectUI()
    {
        diceResultDisplayer = GameObject.Find("DiceResults").GetComponent<DiceResultDisplayer>();
        indicator = GameObject.Find("Indicator").GetComponent<Indicator>();
        destinyTokenField.ConnectDestinyTokenField(this);
        rollButtonConnector.ConnectRollButton(this);
    }


    void Start() // awake로 하면 업데이트 순서 꼬여서 start에 있는 애들임
    {
        
        UpdateEnemy();
        UpdateIndicator();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            health -= 100;
            TakeDamage(1);
        }
        else if(Input.GetKeyDown(KeyCode.S)) 
        {
            enemy.health -= 100;
            enemy.TakeDamage(1);
        }
    }


}
