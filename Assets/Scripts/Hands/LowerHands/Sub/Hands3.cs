using UnityEngine;

[CreateAssetMenu(fileName = "Hands3", menuName = "Hands/Instant/Hands3")]
public class Hands3 : Hands
{
    private void Awake()
    {
        handsName = "파멸적 운명";
        type = HandsType.Sub;
        description =
            "발동 조건: 1 눈이 3개 이상일 때\n" +
            "효과: 6 눈 1개를 추가하고, 운명 토큰을 1개 획득한다.";
    }

    public override bool CheckCondition(Player player, Monster enemy)
    {
        bool condition = player.diceResults[1] >= 3;
        Debug.Log("[파멸적 운명] CheckCondition: player.diceResults[1] >= 3 => " + condition);
        if (condition)
        {
            return true;
        }
        return false;
    }

    public override void ExecuteEffect(Player player, Monster enemy)
    {
        Debug.Log("[파멸적 운명] ExecuteEffect: player.diceResults[6] += 1; player.destinyTokenCount += 1;");

        player.diceResults[6] += 1;
        player.destinyTokenCount += 1;
        Debug.Log("[파멸적 운명] 6 눈 1개 추가, 운명 토큰 +1");
    }
}
