using UnityEngine;

[CreateAssetMenu(fileName = "Hands28", menuName = "Hands/ValueScale/Hands28")]
public class Hands28 : Hands
{
    private void Awake()
    {
        handsName = "신속의 예언";
        type = HandsType.ValueScale;
        description =
            "발동 조건: 3, 4, 5 눈 주사위가 각각 1개 이상 나왔을 때\n" +
            "효과: 현재 공격 횟수 × 2만큼 적에게 예언 수치를 부여한다.";
    }

    public override bool CheckCondition(Player player, Monster enemy)
    {
        bool condition = (player.diceResults[3] >= 1 && player.diceResults[4] >= 1 && player.diceResults[5] >= 1);
        Debug.Log("[신속의 예언] CheckCondition: diceResults[3] >= 1 && diceResults[4] >= 1 && diceResults[5] >= 1 => " + condition);
        if (condition)
        {
            return true;
        }
        return false;
    }

    public override void ExecuteEffect(Player player, Monster enemy)
    {
        int totalAttackCount = player.attackCount + player.tempAttackCount;
        int bonus = totalAttackCount * 2;
        Debug.Log("[신속의 예언] ExecuteEffect: bonus = (attackCount + tempAttackCount) * 2 = " + bonus + "; enemy.predictionValue += bonus;");

        enemy.predictionValue += bonus;
        Debug.Log("[신속의 예언] 적 예언 수치 +" + bonus + " (현재 적 예언 수치: " + enemy.predictionValue + ")");
    }
}
