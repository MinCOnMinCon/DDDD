using UnityEngine;

[CreateAssetMenu(fileName = "Hands16", menuName = "Hands/Instant/Hands16")]
public class Hands16 : Hands
{
    private void Awake()
    {
        handsName = "철갑무사";
        type = HandsType.Instant;
        description =
            "발동 조건: 4 눈 주사위가 2개 이상이고, 3 눈 주사위가 1개 이상 나왔을 때\n" +
            "효과: 현재 공격 횟수 × 4 만큼 방어 수치를 획득한다.";
    }

    public override bool CheckCondition(Player player, Monster enemy)
    {
        bool condition = (player.diceResults[4] >= 2 && player.diceResults[3] >= 1);
        Debug.Log("[철갑무사] CheckCondition: player.diceResults[4] >= 2 && player.diceResults[3] >= 1 => " + condition);
        if (condition)
        {
            return true;
        }
        return false;
    }

    public override void ExecuteEffect(Player player, Monster enemy)
    {
        int totalAttackCount = player.attackCount + player.tempAttackCount;
        int bonusDef = totalAttackCount * 4;
        Debug.Log("[철갑무사] ExecuteEffect: defenseValue += (공격 횟수(" + totalAttackCount + ") × 4) = " + bonusDef);

        player.defenseValue += bonusDef;
        Debug.Log("[철갑무사] 방어 수치 +" + bonusDef + " (현재 방어 수치: " + player.defenseValue + ")");
    }
}
