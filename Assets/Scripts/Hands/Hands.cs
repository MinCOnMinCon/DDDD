using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hands : ScriptableObject
{
    // 족보의 발동 순서를 결정하는 유형
    public enum HandsType { Instant, ValueScale, ValueCondition, NextTurn, Sub }

    public string handsName { get; protected set; }

    public string description { get; protected set; }
    public HandsType type { get; protected set; } // 족보 유형 (발동 순서)

 

    // 조건 체크 (자식 클래스가 필수적으로 구현해야 함)
    // 반환: 조건 충족 여부
    public abstract bool CheckCondition(Player player, Monster enemy);

    // 효과 실행 (자식 클래스가 필수적으로 구현해야 함)
    public abstract void ExecuteEffect(Player player, Monster enemy);
}