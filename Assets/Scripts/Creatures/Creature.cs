using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Creature : MonoBehaviour
{
    private int maxHp = 100;
    private int initDiceCount = 7;
    private int initPenaltyDice = 0;

    private int _health;
    public int health
    { 
        get => _health;
        set => _health = Mathf.Max(0,value);
    }
    protected int totalDiceCount;
    public int tempDiceCount {get; set;} 
    public int penaltyDiceCount { get; set; }
    public bool isDied { get; protected set; }

    // 공격/방어 수치 (매 턴 초기화됨)
    private int _attackValue;
    public int attackValue
    {
        get => _attackValue;
        set => _attackValue = Mathf.Max(0, value);
    }
    private int _defenseValue;
    public int defenseValue
    {
        get => _defenseValue;
        set => _defenseValue = Mathf.Max(0, value);
    }

    public int predictionValue { get; set; }

    protected int damagedPrevTurn = 0;//이전턴에 받은 데미지
    protected int attackPrevTurn = 0;//이전턴에 가한 데미지

    // 주사위 관련
    // [0]: 총합, [1]~[6]: 각 눈금의 비율 (플레이어/적 특성에 따라 다름)
    protected int[] diceRatios;
    // [0] 미사용, [1]~[6]: 이번 턴에 나온 해당 눈금의 개수 (매 턴 초기화됨)
    public int[] diceResults;
 

    public Creature enemy { get; protected set; }
    
    
    public virtual void ResetTurnValues() // 턴 종료시 초기화해야 할 데이터 초기화
    {
        attackValue = 0;
        defenseValue = 0;
        for (int i = 1; i < 7; i++)
        {
            this.diceResults[i] = 0;
        }
        tempDiceCount = 0;
    }
    public virtual void ResetCombatValues()// 전투 종료시 초기화해야 할 데이터 초기화
    {
        attackValue = 0;
        defenseValue = 0;
        for (int i = 1; i < 7; i++)
        {
            this.diceResults[i] = 0;
        }
        tempDiceCount = 0;
        totalDiceCount = initDiceCount;
        penaltyDiceCount = initPenaltyDice;
    }

    protected virtual void RollDice() // 주어진 diceRatios 확률로 단일 주사위를 굴려 나온 눈을 diceResults에 저장
    {
        int eye = UnityEngine.Random.Range(0, diceRatios[0]);
        int cumulativeValue = 0;

        for(int i = 1; i < totalDiceCount + tempDiceCount; i++)
        {
            cumulativeValue += diceRatios[i];
            if(cumulativeValue > eye)
            {
                diceResults[i]++;
                break;
            }
        }
                    
    }
    protected void RollPenaltyDice()
    {
        for(int i = 0; i <  penaltyDiceCount; i++)
        {
            int eye = UnityEngine.Random.Range(1, 7);

            diceResults[eye]--;
            Debug.Log($"{eye}의 눈이 1 감소");
        }
    }
    protected virtual void ApplyDice()
    {
        for (int i = 1; i < 7; i++) // 주사위 눈 개수가 음수가 되는 걸 막기 위함
        {
            diceResults[i] = diceResults[i] > 0 ? diceResults[i] : 0;
        }
        // 1 - doom
        penaltyDiceCount += diceResults[1];
        attackValue += diceResults[1] * 2;
        defenseValue += diceResults[1] * 2;

        // 2, 3 - shiled
        defenseValue += diceResults[2] * 2;
        defenseValue += diceResults[3] * 3;

        // 4, 5 - attack
        attackValue += diceResults[4] * 4;
        attackValue += diceResults[5] * 5;

        // 6 - destiny (Player 클래스에서 처리)
    }
    
    protected virtual void IsDied()
    {
        if(health <= 0)
        {
            isDied = true;
        }
    }


    public void Attack()
    {
        attackPrevTurn = enemy.TakeDamage(attackValue);// 이전 턴 데미지만 계산해야 하니 += 에서 =로 바꿈
    }
   
    // 파라미터로 온 damage에서 deffenseValue를 뺀 값만큼 데미지를 입음
    // 입은 데미지만큼 damagedPrevTurn에 저장하고 리턴함 => 리턴한 건 적의 attackPrevTurn에 저장
    public int TakeDamage(int damage) 
    {
        damagedPrevTurn = damage - defenseValue; // 이전 턴 데미지만 계산해야 하니 += 에서 =로 바꿈
        if (damagedPrevTurn > 0)
        {
        
            health -= damagedPrevTurn;
            Debug.Log($"health = {health} | {this.name}");
            IsDied();
            return damagedPrevTurn;
        }
        else
        {
            return 0;
        }
    }
    // 적 객체의 스크립트를 가져오는 함수. player는 monster의 스크립트를, monster는 player의 스크립트를 가져온다.
    // Player에게 적은 Monster, Monster에게 적은 Player
    protected abstract Creature FindEnemy(); // 오로지 적을 찾아서 리턴으로 적 객체를 돌려주는 함수
    public abstract void ActionStart();
    // Start is called before the first frame update
    protected virtual void Awake()
    {
        health = maxHp;
        totalDiceCount = initDiceCount;
        penaltyDiceCount = initPenaltyDice;
        tempDiceCount = 0;
        diceResults = new int[7];
        diceRatios = new int[7];
        diceRatios[0] = 6;
        for (int i = 1; i < 7; i++)
        {
  
            diceRatios[i] = 1;
            diceResults[i] = 0;

        }
    }


}
