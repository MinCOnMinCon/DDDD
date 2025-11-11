using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenseValBar : MonoBehaviour
{
    private Slider defenseValBar;
    
    public void DefenseValUpdate(float defensValue, float playerHealth) // 플레이어 방어 수치 / 플레이어 체력 비율로 슬라이더 값 조정
    {
        float barValue = defensValue/playerHealth;
        Debug.Log(barValue);
        defenseValBar.value = barValue;
        
    }
    
    void Awake()
    {
        defenseValBar = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
