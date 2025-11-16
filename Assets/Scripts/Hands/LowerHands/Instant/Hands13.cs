using UnityEngine;

[CreateAssetMenu(fileName = "Hands13", menuName = "Hands/Instant/Hands13")]
public class Hands13 : Hands
{
    private void Awake()
    {
        handsName = "전광석화";
        type = HandsType.Instant;
        description =
            "발동 조건: 4, 5 눈 주사위의 총합이 3개 이상일 때\n" +
            "효과: 이번 턴 공격 횟수를 1회 증가시킨다.";
    }

    public override bool CheckCondition(Player player, Monster enemy)
    {
        int total = player.diceResults[4] + player.diceResults[5];
        bool condition = total >= 3;
        Debug.Log("[전광석화] CheckCondition: (diceResults[4] + diceResults[5]) >= 3 => " + condition + " (총합: " + total + ")");
        if (condition)
        {
            return true;
        }
        return false;
    }

    public override void ExecuteEffect(Player player, Monster enemy)
    {
        Debug.Log("[전광석화] ExecuteEffect: player.tempAttackCount += 1;");

        player.tempAttackCount += 1;
        Debug.Log("[전광석화] 추가 공격 횟수 +1 (현재 tempAttackCount: " + player.tempAttackCount + ")");
    }
}
