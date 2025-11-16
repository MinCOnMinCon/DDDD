using UnityEngine;

[CreateAssetMenu(fileName = "Hands11", menuName = "Hands/Instant/Hands11")]
public class Hands11 : Hands
{
    private void Awake()
    {
        handsName = "순환하는 운명";
        type = HandsType.Instant;
        description =
            "발동 조건: 6 눈 주사위가 2개 이상 나왔을 때\n" +
            "효과: 운명 토큰을 1개 획득한다.";
    }

    public override bool CheckCondition(Player player, Monster enemy)
    {
        bool condition = player.diceResults[6] >= 2;
        Debug.Log("[순환하는 운명] CheckCondition: player.diceResults[6] >= 2 => " + condition);
        if (condition)
        {
            return true;
        }
        return false;
    }

    public override void ExecuteEffect(Player player, Monster enemy)
    {
        Debug.Log("[순환하는 운명] ExecuteEffect: player.destinyTokenCount += 1;");

        player.destinyTokenCount += 1;
        Debug.Log("[순환하는 운명] 운명 토큰 +1 (현재: " + player.destinyTokenCount + ")");
    }
}
