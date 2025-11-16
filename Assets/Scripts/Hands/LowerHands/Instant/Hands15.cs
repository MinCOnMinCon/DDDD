using UnityEngine;

[CreateAssetMenu(fileName = "Hands15", menuName = "Hands/Instant/Hands15")]
public class Hands15 : Hands
{
    private void Awake()
    {
        handsName = "광전사";
        type = HandsType.Instant;
        description =
            "발동 조건: 5 눈 주사위가 1개 이상이고, 1 눈 주사위가 2개 이상 나왔을 때\n" +
            "효과: 이번 턴 공격 횟수를 2회 증가시키고, 패널티 주사위를 2개 획득한다.";
    }

    public override bool CheckCondition(Player player, Monster enemy)
    {
        bool condition = (player.diceResults[5] >= 1 && player.diceResults[1] >= 2);
        Debug.Log("[광전사] CheckCondition: player.diceResults[5] >= 1 && player.diceResults[1] >= 2 => " + condition);
        if (condition)
        {
            return true;
        }
        return false;
    }

    public override void ExecuteEffect(Player player, Monster enemy)
    {
        Debug.Log("[광전사] ExecuteEffect: player.tempAttackCount += 2; player.penaltyDiceCount += 2;");

        player.tempAttackCount += 2;
        player.penaltyDiceCount += 2;
        Debug.Log("[광전사] 추가 공격 횟수 +2 (현재 tempAttackCount: " + player.tempAttackCount + "), 패널티 주사위 +2 (현재: " + player.penaltyDiceCount + ")");
    }
}
