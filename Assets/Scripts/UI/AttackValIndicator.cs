using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AttackValIndicator : MonoBehaviour
{
    private Slider attackValBar;
    private TMPro.TextMeshProUGUI attackValText;
    public void AttackValUpdate(float attackValue, float enemyHealth) // 플레이어 공격 수치 / 적 체력 비율로 슬라이더 값 조정
    {
        float barValue = attackValue / enemyHealth;
        attackValText.text = attackValue.ToString(); // 슬라이더 위 공격 수치 업데이트
        attackValBar.value = barValue;
        
    }
    
    void Awake()
    {
        attackValBar = GetComponent<Slider>();
        attackValText = transform.Find("AttackValText").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
