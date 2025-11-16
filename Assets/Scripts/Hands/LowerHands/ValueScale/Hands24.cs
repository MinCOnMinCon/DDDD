using UnityEngine;

[CreateAssetMenu(fileName = "Hands24", menuName = "Hands/ValueScale/Hands24")]
public class Hands24 : Hands
{
    private void Awake()
    {
        handsName = "피의 연회";
        type = HandsType.ValueScale;
        description =
            "발동 조건: 패널티 주사위를 3개 보유하고 있고, 2와 3 눈 주사위의 총합이 1개 이상일 때\n" +
            "효과: 현재 공격 수치의 20%만큼 체력을 회복한다.";
    }

    public override bool CheckCondition(Player player, Monster enemy)
    {
        int sum23 = player.diceResults[2] + player.diceResults[3];
        bool condition = (player.penaltyDiceCount >= 3 && sum23 >= 1);
        Debug.Log("[피의 연회] CheckCondition: penaltyDiceCount >= 3 && (diceResults[2] + diceResults[3]) >= 1 => " + condition + " (2,3 합: " + sum23 + ")");
        if (condition)
        {
            return true;
        }
        return false;
    }

    public override void ExecuteEffect(Player player, Monster enemy)
    {
        int heal = Mathf.FloorToInt(player.attackValue * 0.2f);
        Debug.Log("[피의 연회] ExecuteEffect: heal = floor(attackValue * 0.2) = " + heal + "; health += heal;");

        player.health += heal;
        Debug.Log("[피의 연회] 체력 +" + heal + " (현재 체력: " + player.health + ")");
    }
}
