using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenseValIndicator : MonoBehaviour
{
    private Slider defenseValBar;
    private TMPro.TextMeshProUGUI defenseValText;   
    public void DefenseValUpdate(float defenseValue, float playerHealth) // 플레이어 방어 수치 / 플레이어 체력 비율로 슬라이더 값 조정
    {
        float barValue = defenseValue/playerHealth;
        defenseValText.text = defenseValue.ToString(); // 슬라이더 위 방어 수치 업데이트
        defenseValBar.value = barValue;
        
    }
    
    void Awake()
    {
        defenseValBar = GetComponent<Slider>();
        defenseValText = transform.Find("DefenseValText").GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
