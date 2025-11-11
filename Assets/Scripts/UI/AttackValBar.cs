using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackValBar : MonoBehaviour
{
    private Slider attackValBar;
    
    public void AttackValUpdate(float attackValue, float enemyHealth) // 플레이어 공격 수치 / 적 체력 비율로 슬라이더 값 조정
    {
        float barValue = attackValue / enemyHealth;
        Debug.Log(barValue);
        attackValBar.value = barValue;
        
    }
    
    void Awake()
    {
        attackValBar = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
