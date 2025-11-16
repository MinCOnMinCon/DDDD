using UnityEngine;

[CreateAssetMenu(fileName = "Hands5", menuName = "Hands/Sub/Hands5")]
public class Hands5 : Hands
{
    private void Awake()
    {
        handsName = "요새";
        type = HandsType.Sub;
        description =
            "발동 조건: 2 눈이 2개 이상 또는 3 눈이 2개 이상일 때\n" +
            "효과: 2 눈 1개 또는 3 눈 1개를 추가로 획득한다.";
    }

    public override bool CheckCondition(Player player, Monster enemy)
    {
        bool condition = player.diceResults[2] >= 2 || player.diceResults[3] >= 2;
        Debug.Log("[요새] CheckCondition: player.diceResults[2] >= 2 || player.diceResults[3] >= 2 => " + condition);
        if (condition)
        {
            return true;
        }
        return false;
    }

    public override void ExecuteEffect(Player player, Monster enemy)
    {
        Debug.Log("[요새] ExecuteEffect: if (player.diceResults[2] >= 2) { player.diceResults[2] += 1; } else { player.diceResults[3] += 1; }");

        if (player.diceResults[2] >= 2)
        {
            player.diceResults[2] += 1;
            Debug.Log("[요새] 2 눈 1개 추가");
        }
        else
        {
            player.diceResults[3] += 1;
            Debug.Log("[요새] 3 눈 1개 추가");
        }
    }
}
