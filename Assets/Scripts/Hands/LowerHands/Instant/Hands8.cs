using UnityEngine;

[CreateAssetMenu(fileName = "Hands8", menuName = "Hands/Instant/Hands8")]
public class Hands8 : Hands
{
    private void Awake()
    {
        handsName = "운명의 스트레이트";
        type = HandsType.Instant;
        description =
            "발동 조건: 1, 2, 3, 4, 5 눈이 각각 1개 이상일 때\n" +
            "효과: 운명 토큰을 3개 획득한다.";
    }

    public override bool CheckCondition(Player player, Monster enemy)
    {
        bool condition =
            player.diceResults[1] >= 1 &&
            player.diceResults[2] >= 1 &&
            player.diceResults[3] >= 1 &&
            player.diceResults[4] >= 1 &&
            player.diceResults[5] >= 1;

        Debug.Log("[운명의 스트레이트] CheckCondition: 1~5 눈이 각각 1개 이상 => " + condition);
        if (condition)
        {
            return true;
        }
        return false;
    }

    public override void ExecuteEffect(Player player, Monster enemy)
    {
        Debug.Log("[운명의 스트레이트] ExecuteEffect: player.destinyTokenCount += 3;");

        player.destinyTokenCount += 3;
        Debug.Log("[운명의 스트레이트] 운명 토큰 +3");
    }
}
