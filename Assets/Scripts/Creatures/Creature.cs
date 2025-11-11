using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    private int maxHp = 100;
    private int initDiceCount = 7;
    private int initPenaltyDice = 0;

    protected int health;
    protected int totalDiceCount;
    protected int tempDiceCount = 0; // i
    protected int penaltyDiceCount;

    // 공격/방어 수치 (매 턴 초기화됨)
    protected int attackValue = 0;
    protected int defenseValue = 0;

    // 주사위 관련
    // [0]: 총합, [1]~[6]: 각 눈금의 비율 (플레이어/적 특성에 따라 다름)
    protected int[] diceRatios;
    // [0] 미사용, [1]~[6]: 이번 턴에 나온 해당 눈금의 개수 (매 턴 초기화됨)
    protected int[] diceResults;

    // 족보 및 버프
    // protected Dictionary<HandObject, int> activeHands = new Dictionary<HandObject, int>();
    // protected List<BuffDebuff> buffDebuffs = new List<BuffDebuff>();

    // 생성자 (기본값 설정)
    public Creature()
    {
        health = maxHp;
        totalDiceCount = initDiceCount;
        penaltyDiceCount = initPenaltyDice;
        diceResults = new int[7];
        diceRatios = new int[7];
        diceRatios[0] = 6;
        for(int i = 1; i < 7;i++)
        {
            diceRatios[i] = 1;
            diceResults[i] = 0; 
        
        }
        // this.activeHands = new Dictionary<HandObject, int>();
        // this.buffDebuffs = new List<BuffDebuff>();
    }
    
    public void ResetTurnValues() // 턴 종료시 초기화해야 할 데이터 초기화
    {
        attackValue = 0;
        defenseValue = 0;
        for (int i = 1; i < 7; i++)
        {
            this.diceResults[i] = 0;
        }
        tempDiceCount = 0;
    }
    protected virtual void RollDice() // 주어진 diceRatios 확률로 단일 주사위를 굴려 나온 눈을 diceResults에 저장
    {
        int eye = Random.Range(0, diceRatios[0]);
        int cumulativeValue = 0;

        for(int i = 1; i < 7; i++)
        {
            cumulativeValue += diceRatios[i];
            if(cumulativeValue > eye)
            {
                diceResults[i]++;
                break;
            }
        }
                    
    }
    protected void ApplyDice()
    {
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
    // Start is called before the first frame update
    void Awake()
    {
        health = maxHp;
        totalDiceCount = initDiceCount;
        penaltyDiceCount = initPenaltyDice;
        diceResults = new int[7];
        diceRatios = new int[7];
        diceRatios[0] = 6;
        for (int i = 1; i < 7; i++)
        {
            diceRatios[i] = 1;
            diceResults[i] = 0;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
