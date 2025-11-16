using UnityEngine;

[CreateAssetMenu(fileName = "Hands35", menuName = "Hands/NextTurn/Hands35")]
public class Hands35 : Hands
{
    private void Awake()
    {
        handsName = "난무의 경지";
        type = HandsType.NextTurn;
        description =
            "발동 조건: 이번 턴 최종 공격 횟수가 3회 이상이고, 4 눈 주사위가 1개 이상 나왔을 때\n" +
            "효과: 다음 턴에 사용할 공격 횟수를 1회 증가시키는 보너스를 획득한다.";
    }

    public override bool CheckCondition(Player player, Monster enemy)
    {
        int totalAttackCount = player.attackCount + player.tempAttackCount;
        bool condition = (totalAttackCount >= 3 && player.diceResults[4] >= 1);
        Debug.Log("[난무의 경지] CheckCondition: (attackCount + tempAttackCount) >= 3 && diceResults[4] >= 1 => " + condition + " (최종 공격 횟수: " + totalAttackCount + ", 4 눈 개수: " + player.diceResults[4] + ")");
        if (condition)
        {
            return true;
        }
        return false;
    }

    public override void ExecuteEffect(Player player, Monster enemy)
    {
        Debug.Log("[난무의 경지] ExecuteEffect: 다음 턴용 추가 공격 횟수 보너스로 tempAttackCount += 1;");

        player.tempAttackCount += 1;
        Debug.Log("[난무의 경지] 다음 턴 추가 공격 횟수 보너스 +1 (현재 tempAttackCount: " + player.tempAttackCount + ")");
    }
}
