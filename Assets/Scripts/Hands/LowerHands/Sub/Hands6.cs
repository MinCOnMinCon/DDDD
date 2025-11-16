using UnityEngine;

[CreateAssetMenu(fileName = "Hands6", menuName = "Hands/Sub/Hands6")]
public class Hands6 : Hands
{
    private void Awake()
    {
        handsName = "앙 가르드";
        type = HandsType.Sub;
        description =
            "발동 조건: 4 눈이 2개 이상 또는 5 눈이 2개 이상일 때\n" +
            "효과: 4 눈 1개 또는 5 눈 1개를 추가로 획득한다.";
    }

    public override bool CheckCondition(Player player, Monster enemy)
    {
        bool condition = player.diceResults[4] >= 2 || player.diceResults[5] >= 2;
        Debug.Log("[앙 가르드] CheckCondition: player.diceResults[4] >= 2 || player.diceResults[5] >= 2 => " + condition);
        if (condition)
        {
            return true;
        }
        return false;
    }

    public override void ExecuteEffect(Player player, Monster enemy)
    {
        Debug.Log("[앙 가르드] ExecuteEffect: if (player.diceResults[4] >= 2) { player.diceResults[4] += 1; } else { player.diceResults[5] += 1; }");

        if (player.diceResults[4] >= 2)
        {
            player.diceResults[4] += 1;
            Debug.Log("[앙 가르드] 4 눈 1개 추가");
        }
        else
        {
            player.diceResults[5] += 1;
            Debug.Log("[앙 가르드] 5 눈 1개 추가");
        }
    }
}
