using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public partial class HandsManager : MonoBehaviour
{

    private Dictionary<int, Func<Player, Monster, bool>> conditionFuncs = new Dictionary<int, Func<Player, Monster, bool>>();
    private Dictionary<int, Action<Player, Monster>> executionFuncs = new Dictionary<int, Action<Player, Monster>>();
    [SerializeField]
    private HandsDatabase handsDatabase;
    private int numOfReward = 2;
    public class HandsInstance{
        public HandsInstance(Hands hand, bool isActive, HandsUI ui)
        {
            this.hand = hand;
            this.isActive = isActive;
            this.ui = ui;
        }
        public Hands hand;
        public bool isActive;
        public HandsUI ui;
    }
    public event Action<HandsInstance> onHandsAdded;
    public event Action<HandsInstance> onHandsExecuted;
    public event Action<HandsInstance> onHandsDelete;

    // 족보 유형별 리스트 
    // 족보가 획득될 때 AddHands 함수를 통해 이곳에 추가됩니다.
    private List<HandsInstance> subHandsList = new List<HandsInstance>();
    private List<HandsInstance> instantHandsList = new List<HandsInstance>();
    private List<HandsInstance> valueScaleHandsList = new List<HandsInstance>();
    private List<HandsInstance> valueConditionHandsList = new List<HandsInstance>();
    private List<HandsInstance> nextTurnHandsList = new List<HandsInstance>();

    public void ApplySubHands(Player player, Monster monster)
    {
        Debug.Log("--- sub 족보 적용 시작 ---");
        ExecuteHandsList(subHandsList, player, monster);
        Debug.Log("--- sub 족보 적용 완료 ---");
    }
    public void ApplyFourHands(Player player, Monster enemy)
    {
        Debug.Log("--- 족보 적용 시작 ---");

        
        // 1. 즉발형 족보 적용 
        ExecuteHandsList(instantHandsList, player, enemy);

        // 2. 수치비례형 족보 적용 (즉발형 결과 및 수치에 비례)
        ExecuteHandsList(valueScaleHandsList, player, enemy);

        // 3. 수치조건형 족보 적용 (모든 수치 확정 후 최종 조건 체크)
        ExecuteHandsList(valueConditionHandsList, player, enemy);

        // 4. 미래형 족보 적용 (다음 턴 버프 등록)
        ExecuteHandsList(nextTurnHandsList, player, enemy);

        Debug.Log("--- 족보 적용 완료 ---");
    }
    public void ResetAllHands()
    {
        ResetHandsList(subHandsList);
        ResetHandsList(instantHandsList);
        ResetHandsList(valueScaleHandsList);
        ResetHandsList(valueConditionHandsList);
        ResetHandsList(nextTurnHandsList);
    }

    // 외부에서 족보를 획득했을 때 호출하여 리스트에 추가합니다.
    public void AddHand(Hands hand)
    {
        HandsInstance inst = new HandsInstance(hand, false, null);
        // 족보의 type에 따라 올바른 리스트에 추가
        switch (hand.type)
        {
            case Hands.HandsType.Sub:
                subHandsList.Add(inst);
                break;
            case Hands.HandsType.Instant:
                instantHandsList.Add(inst);
                break;
            case Hands.HandsType.ValueScale:
                valueScaleHandsList.Add(inst);
                break;
            case Hands.HandsType.ValueCondition:
                valueConditionHandsList.Add(inst);
                break;
            case Hands.HandsType.NextTurn:
                nextTurnHandsList.Add(inst);
                break;
        }
        onHandsAdded?.Invoke(inst);
        Debug.Log($"족보 획득: {hand.handsName} ({hand.type} 리스트에 추가됨)");
    }
    public void DeleteAllHands()
    {
        DeleteHandsList(subHandsList);
        DeleteHandsList(instantHandsList);
        DeleteHandsList(valueScaleHandsList);
        DeleteHandsList(valueConditionHandsList);
        DeleteHandsList(nextTurnHandsList);

    }
    private void DeleteHandsList(List<HandsInstance> handsList)
    {
        foreach (HandsInstance hand in handsList)
        {
            onHandsDelete?.Invoke(hand);
        }
        handsList.Clear();
    }

    // 족보 리스트를 순회하며 조건 체크 및 효과 실행
    private void ExecuteHandsList(List<HandsInstance> handsList, Player player, Monster enemy)
    {
      
        foreach (HandsInstance handInst in handsList)
        {
         
            if (conditionFuncs[handInst.hand.key](player, enemy))
            {
                executionFuncs[handInst.hand.key](player, enemy);
           
                onHandsExecuted?.Invoke(handInst);
            }
        }
    }

    private void ResetHandsList(List<HandsInstance> handsList)
    {
        foreach (HandsInstance handsInst in handsList)
        {
            handsInst.ui.SetActive(false);
        }
    }
    private void Awake()
    {
        // --- 모든 Condition 등록 ---
        conditionFuncs = new Dictionary<int, Func<Player, Monster, bool>>()
        {
        { 1,  Condition1 },
        { 2,  Condition2 },
        { 3,  Condition3 },
        { 4,  Condition4 },
        { 5,  Condition5 },
        { 6,  Condition6 },
        { 7,  Condition7 },
        { 8,  Condition8 },
        { 9,  Condition9 },
        { 10, Condition10 },
        { 11, Condition11 },
        { 12, Condition12 },
        { 13, Condition13 },
        { 14, Condition14 },
        { 15, Condition15 },
        { 16, Condition16 },
        { 17, Condition17 },
        { 18, Condition18 },
        { 19, Condition19 },
        { 20, Condition20 },
        { 21, Condition21 },
        { 22, Condition22 },
        { 24, Condition24 },
        { 25, Condition25 },
        { 26, Condition26 },
        { 27, Condition27 },
        { 28, Condition28 },
        { 29, Condition29 },
        { 30, Condition30 },
        { 31, Condition31 },
        { 32, Condition32 },
        { 33, Condition33 },
        { 34, Condition34 },
        { 36, Condition36 },
        { 37, Condition37 }
        };

        // --- 모든 Execution 등록 ---
        executionFuncs = new Dictionary<int, Action<Player, Monster>>()
        {
        { 1,  Execution1 },
        { 2,  Execution2 },
        { 3,  Execution3 },
        { 4,  Execution4 },
        { 5,  Execution5 },
        { 6,  Execution6 },
        { 7,  Execution7 },
        { 8,  Execution8 },
        { 9,  Execution9 },
        { 10, Execution10 },
        { 11, Execution11 },
        { 12, Execution12 },
        { 13, Execution13 },
        { 14, Execution14 },
        { 15, Execution15 },
        { 16, Execution16 },
        { 17, Execution17 },
        { 18, Execution18 },
        { 19, Execution19 },
        { 20, Execution20 },
        { 21, Execution21 },
        { 22, Execution22 },
        { 24, Execution24 },
        { 25, Execution25 },
        { 26, Execution26 },
        { 27, Execution27 },
        { 28, Execution28 },
        { 29, Execution29 },
        { 30, Execution30 },
        { 31, Execution31 },
        { 32, Execution32 },
        { 33, Execution33 },
        { 34, Execution34 },
        { 36, Execution36 },
        { 37, Execution37 }
        };
    }
    private void OnEnable()
    {
        Monster.onMonsterDied += GetRewardHands;
    }
    private void GetRewardHands()
    {
        LogEvent.onLog?.Invoke("당신의 보상은...");
        for(int i = 0; i < numOfReward; i++)
        {
            int handsKey = UnityEngine.Random.Range(1, 38);
            while(handsKey == 23  ||  handsKey == 35)
            {
                handsKey = UnityEngine.Random.Range(1, 38);
            }
            Hands rewardHand= handsDatabase.handsList[handsKey];
            Debug.Log(handsKey);
            AddHand(rewardHand);
            LogEvent.onLog?.Invoke($"{rewardHand.handsName}이다..!");
        }



    }
    private void Start()
    {
        AddHand(handsDatabase.handsList[9]);
        AddHand(handsDatabase.handsList[1]);
        AddHand(handsDatabase.handsList[2]);

        /*for(int i = 1; i < 38; i++)
        {
            if(i == 23 || i == 35)
            {
                continue;
            }
            AddHand(handsDatabase.handsList[i]);
        }*/


    }
    private void OnDisable()
    {
        Monster.onMonsterDied -= GetRewardHands;
    }
}

partial class HandsManager {

        // ---------------------------------------------------------------
    //  1. 최선의 방어는..
    // ---------------------------------------------------------------
    public bool Condition1(Player p, Monster m)
    {
        return (p.diceResults[2] >= 2) || (p.diceResults[3] >= 2);
    }
    public void Execution1(Player p, Monster m)
    {
        if (p.diceResults[2] >= 2)
            p.diceResults[4]++;   // 2 두개 → 4 추가
        else
            p.diceResults[5]++;   // 3 두개 → 5 추가
    }

    // ---------------------------------------------------------------
    //  2. 공격적 방어
    // ---------------------------------------------------------------
    public bool Condition2(Player p, Monster m)
    {
        return (p.diceResults[4] >= 2) || (p.diceResults[5] >= 2);
    }
    public void Execution2(Player p, Monster m)
    {
        if (p.diceResults[4] >= 2)
            p.diceResults[2]++;  // 4 두개 → 2 추가
        else
            p.diceResults[3]++;  // 5 두개 → 3 추가
    }

    // ---------------------------------------------------------------
    //  3. 파멸적 운명
    // ---------------------------------------------------------------
    public bool Condition3(Player p, Monster m)
    {
        return p.diceResults[1] >= 3;
    }
    public void Execution3(Player p, Monster m)
    {
        p.diceResults[6]++;
        p.destinyTokenCount++;
    }

    // ---------------------------------------------------------------
    //  4. 끝없는 파멸
    // ---------------------------------------------------------------
    public bool Condition4(Player p, Monster m)
    {
        return p.diceResults[1] >= 2;
    }
    public void Execution4(Player p, Monster m)
    {
        p.penaltyDiceCount++;
    }

    // ---------------------------------------------------------------
    //  5. 요새
    // ---------------------------------------------------------------
    public bool Condition5(Player p, Monster m)
    {
        return (p.diceResults[2] >= 2) || (p.diceResults[3] >= 2);
    }
    public void Execution5(Player p, Monster m)
    {
        if (p.diceResults[2] >= 2)
            p.diceResults[2]++;
        else
            p.diceResults[3]++;
    }

    // ---------------------------------------------------------------
    //  6. 앙 가르드
    // ---------------------------------------------------------------
    public bool Condition6(Player p, Monster m)
    {
        return (p.diceResults[4] >= 2) || (p.diceResults[5] >= 2);
    }
    public void Execution6(Player p, Monster m)
    {
        if (p.diceResults[4] >= 2)
            p.diceResults[4]++;
        else
            p.diceResults[5]++;
    }

    // ---------------------------------------------------------------
    //  7. 예언의 서막
    // ---------------------------------------------------------------
    public bool Condition7(Player p, Monster m)
    {
        return p.diceResults[2] >= 2;
    }
    public void Execution7(Player p, Monster m)
    {
        m.predictionValue += 2;
        p.defenseValue += 2;
    }

    // ---------------------------------------------------------------
    //  8. 운명의 스트레이트
    // ---------------------------------------------------------------
    public bool Condition8(Player p, Monster m)
    {
        return p.diceResults[1] >= 1 &&
               p.diceResults[2] >= 1 &&
               p.diceResults[3] >= 1 &&
               p.diceResults[4] >= 1 &&
               p.diceResults[5] >= 1;
    }
    public void Execution8(Player p, Monster m)
    {
        p.destinyTokenCount += 3;
    }

    // ---------------------------------------------------------------
    //  9. 패널티 소멸
    // ---------------------------------------------------------------
    public bool Condition9(Player p, Monster m)
    {
        return p.penaltyDiceCount >= 2;
    }
    public void Execution9(Player p, Monster m)
    {
        p.penaltyDiceCount -= 2;
        p.health += 5;
    }

    // ---------------------------------------------------------------
    // 10. 도박사의 보상
    // ---------------------------------------------------------------
    public bool Condition10(Player p, Monster m)
    {
        return (p.diceResults[2] >= 1 &&
                p.diceResults[4] >= 1 &&
                p.diceResults[6] >= 1);
    }
    public void Execution10(Player p, Monster m)
    {
        p.tempDiceCount++;
        p.attackValue += 5;
        p.defenseValue += 5;
    }

    // ---------------------------------------------------------------
    // 11. 순환하는 운명
    // ---------------------------------------------------------------
    public bool Condition11(Player p, Monster m)
    {
        return p.diceResults[6] >= 2;
    }
    public void Execution11(Player p, Monster m)
    {
        p.destinyTokenCount++;
    }

    // ---------------------------------------------------------------
    // 12. 운명의 제어
    // ---------------------------------------------------------------
    public bool Condition12(Player p, Monster m)
    {
        return p.destinyTokenCount >= 3;
    }
    public void Execution12(Player p, Monster m)
    {
        p.destinyTokenCount -= 1;
        p.attackValue += 7;
        p.defenseValue += 7;
    }

    // ---------------------------------------------------------------
    // 13. 전광석화
    // ---------------------------------------------------------------
    public bool Condition13(Player p, Monster m)
    {
        return (p.diceResults[4] + p.diceResults[5]) >= 3;
    }
    public void Execution13(Player p, Monster m)
    {
        p.tempAttackCount += 1;
    }

    // ---------------------------------------------------------------
    // 14. 무력 증강
    // ---------------------------------------------------------------
    public bool Condition14(Player p, Monster m)
    {
        return p.diceResults[5] >= 3;
    }
    public void Execution14(Player p, Monster m)
    {
        p.attackValue += p.diceResults[5] * 5;
    }

    // ---------------------------------------------------------------
    // 15. 광전사
    // ---------------------------------------------------------------
    public bool Condition15(Player p, Monster m)
    {
        return (p.diceResults[5] >= 1 && p.diceResults[1] >= 2);
    }
    public void Execution15(Player p, Monster m)
    {
        p.tempAttackCount += 2;
        p.penaltyDiceCount += 2;
    }

    // ---------------------------------------------------------------
    // 17. 연격
    // ---------------------------------------------------------------
    public bool Condition17(Player p, Monster m)
    {
        return (p.diceResults[4] + p.diceResults[5]) >= 4;
    }
    public void Execution17(Player p, Monster m)
    {
        int count = (p.diceResults[4] + p.diceResults[5]) / 3;
        p.tempAttackCount += count;
    }

    // ---------------------------------------------------------------
    // 18. 둠해머
    // ---------------------------------------------------------------
    public bool Condition18(Player p, Monster m)
    {
        return p.penaltyDiceCount >= 3;
    }
    public void Execution18(Player p, Monster m)
    {
        p.tempAttackCount += 2;
        p.penaltyDiceCount -= 2;
    }

    // ---------------------------------------------------------------
    // 19. 파멸
    // ---------------------------------------------------------------
    public bool Condition19(Player p, Monster m)
    {
        return p.penaltyDiceCount >= 6;
    }
    public void Execution19(Player p, Monster m)
    {
        p.attackValue += 70;
        p.penaltyDiceCount -= 5;
    }

    // ---------------------------------------------------------------
    // 20. 현실 왜곡
    // ---------------------------------------------------------------
    public bool Condition20(Player p, Monster m)
    {
        return (p.diceResults[2] + p.diceResults[3]) >= 4;
    }
    public void Execution20(Player p, Monster m)
    {
        m.predictionValue += 5;
        p.tempDiceCount += 1;
    }
    // ---------------------------------------------------------------
    // 36. 행운의 가속
    // ---------------------------------------------------------------
    public bool Condition36(Player p, Monster m)
    {
        return p.diceResults[6] >= 4;
    }
    public void Execution36(Player p, Monster m)
    {

        p.tempDiceCount += 2;
    }
    // ---------------------------------------------------------------
    // 37. 다이스의 연금술
    // ---------------------------------------------------------------
    public bool Condition37(Player p, Monster m)
    {
        return (p.diceResults[2] >= 1 &&
                p.diceResults[3] >= 1 &&
                p.diceResults[4] >= 1 &&
                p.diceResults[5] >= 1);
    }
    public void Execution37(Player p, Monster m)
    {
        p.attackValue += 9;
        p.defenseValue += 9;
    }
}
partial class HandsManager
{
    // ================================================================
    // 16. 철갑무사
    // 조건: 4 ≥2 & 3 ≥1
    // 효과: (공격 횟수 × 4) 만큼 방어 획득
    // ================================================================
    public bool Condition16(Player p, Monster m)
    {
        return (p.diceResults[4] >= 2 && p.diceResults[3] >= 1);
    }

    public void Execution16(Player p, Monster m)
    {
        int totalAttackCount = p.attackCount + p.tempAttackCount;
        p.defenseValue += totalAttackCount * 4;
    }


    // ================================================================
    // 21. 자기 실현적 예언
    // 조건: 6 ≥3 + 패널티 ≥2
    // 효과: 운명 → 패널티 변환, 변환당 공격 +3
    // ================================================================
    public bool Condition21(Player p, Monster m)
    {
        return (p.diceResults[6] >= 3 && p.penaltyDiceCount >= 2);
    }

    public void Execution21(Player p, Monster m)
    {
        int convertible = Mathf.Min(p.destinyTokenCount, p.penaltyDiceCount);
        p.destinyTokenCount -= convertible;
        p.penaltyDiceCount += convertible;
        p.attackValue += convertible * 3;
    }


    // ================================================================
    // 22. 속죄의 폭풍
    // 조건: 패널티 ≥3 + (4 OR 5 ≥1)
    // 효과: 공격 = 패널티 × 5, 패널티 -1
    // ================================================================
    public bool Condition22(Player p, Monster m)
    {
        return (p.penaltyDiceCount >= 3) &&
               (p.diceResults[4] >= 1 || p.diceResults[5] >= 1);
    }

    public void Execution22(Player p, Monster m)
    {
        p.attackValue = p.penaltyDiceCount * 5;
        p.penaltyDiceCount -= 1;
    }


    // ================================================================
    // 24. 피의 연회
    // 조건: 패널티 ≥3 + (2 OR 3 ≥1)
    // 효과: 공격의 20% 체력 회복
    // ================================================================
    public bool Condition24(Player p, Monster m)
    {
        return (p.penaltyDiceCount >= 3) &&
               (p.diceResults[2] >= 1 || p.diceResults[3] >= 1);
    }

    public void Execution24(Player p, Monster m)
    {
        int heal = Mathf.FloorToInt(p.attackValue * 0.2f);
        p.health += heal;
    }


    // ================================================================
    // 25. 파상 공세
    // 조건: 4 ≥3
    // 효과: (공격 ÷ 8) 만큼 공격 횟수 증가
    // ================================================================
    public bool Condition25(Player p, Monster m)
    {
        return p.diceResults[4] >= 3;
    }

    public void Execution25(Player p, Monster m)
    {
        int add = p.attackValue / 8;
        p.tempAttackCount += add;
    }


    // ================================================================
    // 26. 흡수 타격
    // 조건: 3·4 각각 1개
    // 효과: (공격 횟수 × 4) 체력 회복
    // ================================================================
    public bool Condition26(Player p, Monster m)
    {
        return (p.diceResults[3] >= 1 && p.diceResults[4] >= 1);
    }

    public void Execution26(Player p, Monster m)
    {
        int totalAttackCount = p.attackCount + p.tempAttackCount;
        p.health += totalAttackCount * 4;
    }


    // ================================================================
    // 27. 고통의 예언
    // 조건: 4·5 각각 1개
    // 효과: 공격의 10% 예언 부여
    // ================================================================
    public bool Condition27(Player p, Monster m)
    {
        return (p.diceResults[4] >= 1 && p.diceResults[5] >= 1);
    }

    public void Execution27(Player p, Monster m)
    {
        int add = Mathf.FloorToInt(p.attackValue * 0.1f);
        m.predictionValue += add;
    }


    // ================================================================
    // 28. 신속의 예언
    // 조건: 3·4·5 각각 1개
    // 효과: 공격 횟수 ×2 예언
    // ================================================================
    public bool Condition28(Player p, Monster m)
    {
        return (p.diceResults[3] >= 1 &&
                p.diceResults[4] >= 1 &&
                p.diceResults[5] >= 1);
    }

    public void Execution28(Player p, Monster m)
    {
        int totalAttackCount = p.attackCount + p.tempAttackCount;
        m.predictionValue += totalAttackCount * 2;
    }
}

partial class HandsManager {
    // ================================================================
    // 29. 운명 조작
    // 조건: 예언 ≥ 6 + 6 눈 ≥ 1
    // 효과: 운명 토큰 +1, 방어 +5
    // ================================================================
    public bool Condition29(Player p, Monster m)
    {
        return (m.predictionValue >= 6 && p.diceResults[6] >= 1);
    }

    public void Execution29(Player p, Monster m)
    {
        p.destinyTokenCount += 1;
        p.defenseValue += 5;
    }


    // ================================================================
    // 30. 치유의 징조
    // 조건: 예언 ≥ 9 + 2 눈 ≥ 1
    // 효과: 체력 +7, 방어 +6
    // ================================================================
    public bool Condition30(Player p, Monster m)
    {
        return (m.predictionValue >= 9 && p.diceResults[2] >= 1);
    }

    public void Execution30(Player p, Monster m)
    {
        p.health += 7;
        p.defenseValue += 6;
    }


    // ================================================================
    // 31. 예지된 방어
    // 조건: 예언 ≥ 10 + 3 눈 ≥ 1
    // 효과: 방어 +15
    // ================================================================
    public bool Condition31(Player p, Monster m)
    {
        return (m.predictionValue >= 10 && p.diceResults[3] >= 1);
    }

    public void Execution31(Player p, Monster m)
    {
        p.defenseValue += 15;
    }


    // ================================================================
    // 32. 예언 폭발
    // 조건: 예언 ≥ 11 + 1 눈 ≥ 1
    // 효과: 적 주사위 1개 제거
    // ================================================================
    public bool Condition32(Player p, Monster m)
    {
        return (m.predictionValue >= 11 && p.diceResults[1] >= 1);
    }

    public void Execution32(Player p, Monster m)
    {
        for (int i = 1; i <= 6; i++)
        {
            if (m.diceResults[i] > 0)
            {
                m.diceResults[i]--;
                break;
            }
        }
    }


    // ================================================================
    // 33. 예언 : 죽음
    // 조건: 예언 ≥ 15 + (4 ≥2 OR 5 ≥2)
    // 효과: 적 예언 0, 공격 +40
    // ================================================================
    public bool Condition33(Player p, Monster m)
    {
        bool four = p.diceResults[4] >= 2;
        bool five = p.diceResults[5] >= 2;
        return (m.predictionValue >= 15 && (four || five));
    }

    public void Execution33(Player p, Monster m)
    {
        m.predictionValue = 0;
        p.attackValue += 40;
    }


    // ================================================================
    // 34. 속전속결
    // 조건: 최종 공격 횟수 ≥ 4
    // 효과: 공격 +10
    // ================================================================
    public bool Condition34(Player p, Monster m)
    {
        int totalAttackCount = p.attackCount + p.tempAttackCount;
        return totalAttackCount >= 4;
    }

    public void Execution34(Player p, Monster m)
    {
        p.attackValue += 10;
    }
}