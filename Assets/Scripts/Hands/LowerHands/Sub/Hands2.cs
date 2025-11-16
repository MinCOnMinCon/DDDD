using UnityEngine;

[CreateAssetMenu(fileName = "Hands2", menuName = "Hands/Instant/Hands2")]
public class Hands2 : Hands
{
    private void Awake()
    {
        handsName = "공격적 방어";
        type = HandsType.Sub;
        description =
            "발동 조건: 4 눈이 2개 이상 또는 5 눈이 2개 이상일 때\n" +
            "효과: 2 눈 1개 또는 3 눈 1개를 추가로 획득한다.";
    }

    public override bool CheckCondition(Player player, Monster enemy)
    {
        bool condition = player.diceResults[4] >= 2 || player.diceResults[5] >= 2;
        Debug.Log("[공격적 방어] CheckCondition: player.diceResults[4] >= 2 || player.diceResults[5] >= 2 => " + condition);
        if (condition)
        {
            return true;
        }
        return false;
    }

    public override void ExecuteEffect(Player player, Monster enemy)
    {
        Debug.Log("[공격적 방어] ExecuteEffect: if (player.diceResults[4] >= 2) { player.diceResults[2] += 1; } else { player.diceResults[3] += 1; }");

        if (player.diceResults[4] >= 2)
        {
            player.diceResults[2] += 1;
            Debug.Log("[공격적 방어] 2 눈 1개 추가");
        }
        else
        {
            player.diceResults[3] += 1;
            Debug.Log("[공격적 방어] 3 눈 1개 추가");
        }
    }
}
