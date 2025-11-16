using UnityEngine;

[CreateAssetMenu(fileName = "Hands25", menuName = "Hands/ValueScale/Hands25")]
public class Hands25 : Hands
{
    private void Awake()
    {
        handsName = "파상 공세";
        type = HandsType.ValueScale;
        description =
            "발동 조건: 4 눈 주사위가 3개 이상 나왔을 때\n" +
            "효과: 이번 턴 현재 공격 수치를 8로 나눈 몫만큼 공격 횟수를 추가로 획득한다.";
    }

    public override bool CheckCondition(Player player, Monster enemy)
    {
        bool condition = player.diceResults[4] >= 3;
        Debug.Log("[파상 공세] CheckCondition: diceResults[4] >= 3 => " + condition);
        if (condition)
        {
            return true;
        }
        return false;
    }

    public override void ExecuteEffect(Player player, Monster enemy)
    {
        int extraAttacks = player.attackValue / 8;
        Debug.Log("[파상 공세] ExecuteEffect: extraAttacks = attackValue / 8 = " + extraAttacks + "; tempAttackCount += extraAttacks;");

        if (extraAttacks > 0)
        {
            player.tempAttackCount += extraAttacks;
            Debug.Log("[파상 공세] 추가 공격 횟수 +" + extraAttacks + " (현재 tempAttackCount: " + player.tempAttackCount + ")");
        }
        else
        {
            Debug.Log("[파상 공세] 추가 공격 횟수가 0이므로 변화 없음.");
        }
    }
}
