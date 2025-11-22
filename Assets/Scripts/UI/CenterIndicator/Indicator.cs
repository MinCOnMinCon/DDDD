using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    [SerializeField]   
    private DefenseValIndicator defenseValIndicator;
    [SerializeField]
    private AttackValIndicator attackValIndicator;
    [SerializeField]
    private DestinyAndPenaltyIndicator destinyAndPenaltyIndicator;
    [SerializeField]
    private HealthAndDiceIndicator healthAndDiceIndicator;


    public void IndicatorUpdate(Player player)
    {
        Debug.Log(healthAndDiceIndicator);
        defenseValIndicator.DefenseValUpdate(player.defenseValue, player.health);
        attackValIndicator.AttackValUpdate(player.attackValue, player.enemy.health);
        destinyAndPenaltyIndicator.DestinyAndPenaltyUpdate(player.destinyTokenCount, player.penaltyDiceCount);
        healthAndDiceIndicator.HealthUpdate(player.health);
        healthAndDiceIndicator.DiceUpdate(player.totalDiceCount, player.tempDiceCount);
    }
    // Start is called before the first frame update
    void Awake()
    {
        //defenseValIndicator = transform.Find("DefenseValIndicator").GetComponent<DefenseValIndicator>();
        //attackValIndicator = transform.Find("AttackValIndicator").GetComponent<AttackValIndicator>();
        //destinyAndPenaltyIndicator = transform.Find("DestinyAndPenaltyIndicator").GetComponent <DestinyAndPenaltyIndicator>();
        //healthAndDiceIndicator = transform.Find("HealthAndDiceIndicator").GetComponent<HealthAndDiceIndicator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
