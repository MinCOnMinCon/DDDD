using UnityEngine;

[CreateAssetMenu(fileName = "Hands17", menuName = "Hands/Instant/Hands17")]
public class Hands17 : Hands
{
    private void Awake()
    {
        handsName = "연격";
        type = HandsType.Instant;
        description =
            "발동 조건: 4, 5 눈 주사위의 총합이 4개 이상일 때\n" +
            "효과: 이번 턴에 (4와 5 눈의 총합 ÷ 3)의 몫만큼 공격 횟수를 추가로 획득한다.";
    }

    public override bool CheckCondition(Player player, Monster enemy)
    {
        int sum = player.diceResults[4] + player.diceResults[5];
        bool condition = sum >= 4;
        Debug.Log("[연격] CheckCondition: (diceResults[4] + diceResults[5]) >= 4 => " + condition + " (총합: " + sum + ")");
        if (condition)
        {
            return true;
        }
        return false;
    }

    public override void ExecuteEffect(Player player, Monster enemy)
    {
        int sum = player.diceResults[4] + player.diceResults[5];
        int extraAttacks = sum / 3;
        Debug.Log("[연격] ExecuteEffect: extraAttacks = (diceResults[4] + diceResults[5]) / 3 = " + extraAttacks + "; player.tempAttackCount += extraAttacks;");

        if (extraAttacks > 0)
        {
            player.tempAttackCount += extraAttacks;
            Debug.Log("[연격] 추가 공격 횟수 +" + extraAttacks + " (현재 tempAttackCount: " + player.tempAttackCount + ")");
        }
        else
        {
            Debug.Log("[연격] 추가 공격 횟수가 0이므로 변화 없음.");
        }
    }
}
