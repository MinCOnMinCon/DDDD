using UnityEngine;

[CreateAssetMenu(fileName = "Hands18", menuName = "Hands/Instant/Hands18")]
public class Hands18 : Hands
{
    private void Awake()
    {
        handsName = "둠해머";
        type = HandsType.Instant;
        description =
            "발동 조건: 패널티 주사위를 3개 이상 보유하고 있을 때\n" +
            "효과: 이번 턴 공격 횟수를 2회 증가시키고, 패널티 주사위를 2개 삭제한다.";
    }

    public override bool CheckCondition(Player player, Monster enemy)
    {
        bool condition = player.penaltyDiceCount >= 3;
        Debug.Log("[둠해머] CheckCondition: player.penaltyDiceCount >= 3 => " + condition);
        if (condition)
        {
            return true;
        }
        return false;
    }

    public override void ExecuteEffect(Player player, Monster enemy)
    {
        Debug.Log("[둠해머] ExecuteEffect: player.tempAttackCount += 2; player.penaltyDiceCount -= 2;");

        player.tempAttackCount += 2;
        player.penaltyDiceCount -= 2;
        Debug.Log("[둠해머] 추가 공격 횟수 +2 (현재 tempAttackCount: " + player.tempAttackCount + "), 패널티 주사위 -2 (현재: " + player.penaltyDiceCount + ")");
    }
}
