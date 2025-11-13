using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthIndicator : MonoBehaviour
{
    private TMPro.TextMeshProUGUI healthText;
    // Start is called before the first frame update

    public void HealthUpdate(int health)
    {
        healthText.text = health.ToString();
    }
    void Awake()
    {
        healthText = GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
