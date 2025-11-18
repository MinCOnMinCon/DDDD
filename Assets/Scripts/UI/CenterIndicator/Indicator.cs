using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    
    private DefenseValIndicator defenseValIndicator;
    private AttackValIndicator attackValIndicator;
    private DestinyAndPenaltyIndicator destinyAndPenaltyIndicator;
    private HealthIndicator healthIndicator;


    public void IndicatorUpdate(Player player)
    {
        defenseValIndicator.DefenseValUpdate(player.defenseValue, player.health);
        attackValIndicator.AttackValUpdate(player.attackValue, player.enemy.health);
        destinyAndPenaltyIndicator.DestinyAndPenaltyUpdate(player.destinyTokenCount, player.penaltyDiceCount);
        healthIndicator.HealthUpdate(player.health);
    }
    // Start is called before the first frame update
    void Awake()
    {
        defenseValIndicator = transform.Find("DefenseValIndicator").GetComponent<DefenseValIndicator>();
        attackValIndicator = transform.Find("AttackValIndicator").GetComponent<AttackValIndicator>();
        
        destinyAndPenaltyIndicator = transform.Find("DestinyAndPenaltyIndicator").GetComponent <DestinyAndPenaltyIndicator>();
        healthIndicator = transform.Find("HealthIndicator").GetComponent<HealthIndicator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
