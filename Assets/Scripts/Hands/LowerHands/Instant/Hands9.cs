using UnityEngine;

[CreateAssetMenu(fileName = "Hands9", menuName = "Hands/Instant/Hands9")]
public class Hands9 : Hands
{
    private void Awake()
    {
        handsName = "패널티 소멸";
        type = HandsType.Instant;
        description =
            "발동 조건: 패널티 주사위를 2개 이상 보유하고 있을 때\n" +
            "효과: 패널티 주사위를 2개 삭제하고, 체력을 5만큼 회복한다.";
    }

    public override bool CheckCondition(Player player, Monster enemy)
    {
        bool condition = player.penaltyDiceCount >= 2;
        Debug.Log("[패널티 소멸] CheckCondition: player.penaltyDiceCount >= 2 => " + condition);
        if (condition)
        {
            return true;
        }
        return false;
    }

    public override void ExecuteEffect(Player player, Monster enemy)
    {
        Debug.Log("[패널티 소멸] ExecuteEffect: player.penaltyDiceCount -= 2; player.health += 5;");

        player.penaltyDiceCount -= 2;
        player.health += 5;
        Debug.Log("[패널티 소멸] 패널티 -2, 체력 +5");
    }
}
