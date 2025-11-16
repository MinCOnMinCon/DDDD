using UnityEngine;

[CreateAssetMenu(fileName = "Hands26", menuName = "Hands/ValueScale/Hands26")]
public class Hands26 : Hands
{
    private void Awake()
    {
        handsName = "흡수 타격";
        type = HandsType.ValueScale;
        description =
            "발동 조건: 3 눈 주사위와 4 눈 주사위가 각각 1개 이상 나왔을 때\n" +
            "효과: 현재 공격 횟수 × 4만큼 체력을 회복한다.";
    }

    public override bool CheckCondition(Player player, Monster enemy)
    {
        bool condition = (player.diceResults[3] >= 1 && player.diceResults[4] >= 1);
        Debug.Log("[흡수 타격] CheckCondition: diceResults[3] >= 1 && diceResults[4] >= 1 => " + condition);
        if (condition)
        {
            return true;
        }
        return false;
    }

    public override void ExecuteEffect(Player player, Monster enemy)
    {
        int totalAttackCount = player.attackCount + player.tempAttackCount;
        int heal = totalAttackCount * 4;
        Debug.Log("[흡수 타격] ExecuteEffect: heal = (attackCount + tempAttackCount) * 4 = " + heal + "; health += heal;");

        player.health += heal;
        Debug.Log("[흡수 타격] 체력 +" + heal + " (현재 체력: " + player.health + ")");
    }
}
