using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Creature
{
    private int numOfDestinyToken = 0;


    [SerializeField]
    private DiceResultDisplayer DiceResultDisplayer;

    public void RollButtonClicked()
    {
        RollDice();
        ApplyDice();
    }

    protected override void ApplyDice()
    {

    }
    protected override void RollDice()
    {
        for (int i = 0; i  < totalDiceCount; i++)
        {
            base.RollDice();
        }
        Debug.Log("버튼 클릭");
        DiceResultDisplayer.ResultUpdate(diceResults);

    }
    // Start is called before the first frame update
    void Awake()
    {
        DiceResultDisplayer.ResultUpdate(diceResults);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
