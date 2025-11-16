using UnityEngine;

[CreateAssetMenu(fileName = "Hands36", menuName = "Hands/Instant/Hands36")]
public class Hands36 : Hands
{
    private void Awake()
    {
        handsName = "행운의 가속";
        type = HandsType.Instant;
        description =
            "발동 조건: 6 눈 주사위가 4개 이상 나왔을 때\n" +
            "효과: 주사위 개수 2개를 추가로 획득한다.";
    }

    public override bool CheckCondition(Player player, Monster enemy)
    {
        bool condition = (player.diceResults[6] >= 4);
        Debug.Log("[행운의 가속] CheckCondition: diceResults[6] >= 4 => " + condition + " (6 눈 개수: " + player.diceResults[6] + ")");
        if (condition)
        {
            return true;
        }
        return false;
    }

    public override void ExecuteEffect(Player player, Monster enemy)
    {
        Debug.Log("[행운의 가속] ExecuteEffect: tempDiceCount += 2;");

        player.tempDiceCount += 2;
        Debug.Log("[행운의 가속] 추가 주사위 +2 (현재 tempDiceCount: " + player.tempDiceCount + ")");
    }
}
