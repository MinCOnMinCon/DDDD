using UnityEngine;

[CreateAssetMenu(fileName = "Hands1", menuName = "Hands/Sub/Hands1")]
public class Hands1 : Hands
{
    private void Awake()
    {
        handsName = "최선의 방어는..";
        type = HandsType.Sub;
        description =
            "발동 조건: 2 눈이 2개 이상 또는 3 눈이 2개 이상일 때\n" +
            "효과: 4 눈 1개 또는 5 눈 1개를 추가로 획득한다.";
    }

    public override bool CheckCondition(Player player, Monster enemy)
    {
        bool condition = player.diceResults[2] >= 2 || player.diceResults[3] >= 2;
        Debug.Log("[최선의 방어는..] CheckCondition: player.diceResults[2] >= 2 || player.diceResults[3] >= 2 => " + condition);
        if (condition)
        {
            return true;
        }
        return false;
    }

    public override void ExecuteEffect(Player player, Monster enemy)
    {
        Debug.Log("[최선의 방어는..] ExecuteEffect: if (player.diceResults[2] >= 2) { player.diceResults[4] += 1; } else { player.diceResults[5] += 1; }");

        if (player.diceResults[2] >= 2)
        {
            player.diceResults[4] += 1;
            Debug.Log("[최선의 방어는..] 4 눈 1개 추가");
        }
        else
        {
            player.diceResults[5] += 1;
            Debug.Log("[최선의 방어는..] 5 눈 1개 추가");
        }
    }
}
