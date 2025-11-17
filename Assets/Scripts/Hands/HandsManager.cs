using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsManager : MonoBehaviour
{
    
    public Hands hands1;
    public Hands hands2;
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

    // 족보 리스트를 순회하며 조건 체크 및 효과 실행
    private void ExecuteHandsList(List<HandsInstance> handsList, Player player, Monster enemy)
    {
      
        foreach (HandsInstance handInst in handsList)
        {
         
            if (handInst.hand.CheckCondition(player, enemy))
            {
                handInst.hand.ExecuteEffect(player, enemy);
           
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

    private void Start()
    {
        AddHand(hands1);
        AddHand(hands2);
        AddHand(hands1);
        AddHand(hands2);
        AddHand(hands1);
        AddHand(hands2);
       
    }
}
