using UnityEngine;

[CreateAssetMenu(fileName = "Hands22", menuName = "Hands/ValueScale/Hands22")]
public class Hands22 : Hands
{
    private void Awake()
    {
        handsName = "속죄의 폭풍";
        type = HandsType.ValueScale;
        description =
            "발동 조건: 패널티 주사위를 3개 이상 보유하고 있고, 4와 5 눈 주사위의 총합이 1개 이상일 때\n" +
            "효과: 패널티 주사위 개수 × 5만큼 공격 수치를 증가시키고, 패널티 주사위를 1개 삭제한다.";
    }

    public override bool CheckCondition(Player player, Monster enemy)
    {
        int sum45 = player.diceResults[4] + player.diceResults[5];
        bool condition = (player.penaltyDiceCount >= 3 && sum45 >= 1);
        Debug.Log("[속죄의 폭풍] CheckCondition: penaltyDiceCount >= 3 && (diceResults[4] + diceResults[5]) >= 1 => " + condition + " (4,5 합: " + sum45 + ")");
        if (condition)
        {
            return true;
        }
        return false;
    }

    public override void ExecuteEffect(Player player, Monster enemy)
    {
        int bonus = player.penaltyDiceCount * 5;
        Debug.Log("[속죄의 폭풍] ExecuteEffect: attackValue += penaltyDiceCount * 5 = " + bonus + "; penaltyDiceCount -= 1;");

        player.attackValue += bonus;
        player.penaltyDiceCount -= 1;
        Debug.Log("[속죄의 폭풍] 공격 수치 +" + bonus + " (현재 공격 수치: " + player.attackValue + "), 패널티 주사위 -1 (현재: " + player.penaltyDiceCount + ")");
    }
}
