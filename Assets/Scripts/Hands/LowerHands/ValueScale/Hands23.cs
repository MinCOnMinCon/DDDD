using UnityEngine;

[CreateAssetMenu(fileName = "Hands23", menuName = "Hands/ValueScale/Hands23")]
public class Hands23 : Hands
{
    private void Awake()
    {
        handsName = "희생의 칼날";
        type = HandsType.ValueScale;
        description =
            "발동 조건: 1 눈 주사위가 2개 이상이고, 4와 5 눈 주사위의 총합이 1개 이상일 때\n" +
            "효과: 1 눈 주사위 개수 × 5만큼 공격 수치를 증가시키고, 패널티 주사위를 2개 삭제한다.";
    }

    public override bool CheckCondition(Player player, Monster enemy)
    {
        int sum45 = player.diceResults[4] + player.diceResults[5];
        bool condition = (player.diceResults[1] >= 2 && sum45 >= 1);
        Debug.Log("[희생의 칼날] CheckCondition: diceResults[1] >= 2 && (diceResults[4] + diceResults[5]) >= 1 => " + condition + " (4,5 합: " + sum45 + ")");
        if (condition)
        {
            return true;
        }
        return false;
    }

    public override void ExecuteEffect(Player player, Monster enemy)
    {
        int bonusAttack = player.diceResults[1] * 5;
        Debug.Log("[희생의 칼날] ExecuteEffect: attackValue += diceResults[1] * 5 = " + bonusAttack + "; penaltyDiceCount -= 2;");

        player.attackValue += bonusAttack;
        player.penaltyDiceCount -= 2;
        Debug.Log("[희생의 칼날] 공격 수치 +" + bonusAttack + " (현재 공격 수치: " + player.attackValue + "), 패널티 주사위 -2 (현재: " + player.penaltyDiceCount + ")");
    }
}
