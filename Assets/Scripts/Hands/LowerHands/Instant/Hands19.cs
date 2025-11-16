using UnityEngine;

[CreateAssetMenu(fileName = "Hands19", menuName = "Hands/Instant/Hands19")]
public class Hands19 : Hands
{
    private void Awake()
    {
        handsName = "파멸";
        type = HandsType.Instant;
        description =
            "발동 조건: 패널티 주사위를 6개 이상 보유하고 있을 때\n" +
            "효과: 공격 수치를 70만큼 증가시키고, 패널티 주사위를 5개 삭제한다.";
    }

    public override bool CheckCondition(Player player, Monster enemy)
    {
        bool condition = player.penaltyDiceCount >= 6;
        Debug.Log("[파멸] CheckCondition: player.penaltyDiceCount >= 6 => " + condition);
        if (condition)
        {
            return true;
        }
        return false;
    }

    public override void ExecuteEffect(Player player, Monster enemy)
    {
        Debug.Log("[파멸] ExecuteEffect: player.attackValue += 70; player.penaltyDiceCount -= 5;");

        player.attackValue += 70;
        player.penaltyDiceCount -= 5;
        Debug.Log("[파멸] 공격 수치 +70 (현재 공격 수치: " + player.attackValue + "), 패널티 주사위 -5 (현재: " + player.penaltyDiceCount + ")");
    }
}
