using UnityEngine;

[CreateAssetMenu(fileName = "Hands4", menuName = "Hands/Sub/Hands4")]
public class Hands4 : Hands
{
    private void Awake()
    {
        handsName = "끝없는 파멸";
        type = HandsType.Sub;
        description =
            "발동 조건: 1 눈이 2개 이상일 때\n" +
            "효과: 패널티 주사위를 1개 추가한다.";
    }

    public override bool CheckCondition(Player player, Monster enemy)
    {
        bool condition = player.diceResults[1] >= 2;
        Debug.Log("[끝없는 파멸] CheckCondition: player.diceResults[1] >= 2 => " + condition);
        if (condition)
        {
            return true;
        }
        return false;
    }

    public override void ExecuteEffect(Player player, Monster enemy)
    {
        Debug.Log("[끝없는 파멸] ExecuteEffect: player.penaltyDiceCount += 1;");

        player.penaltyDiceCount += 1;
        Debug.Log("[끝없는 파멸] 패널티 주사위 +1");
    }
}
