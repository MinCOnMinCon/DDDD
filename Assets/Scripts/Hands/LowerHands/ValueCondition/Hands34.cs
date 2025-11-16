using UnityEngine;

[CreateAssetMenu(fileName = "Hands34", menuName = "Hands/ValueCondition/Hands34")]
public class Hands34 : Hands
{
    private void Awake()
    {
        handsName = "속전속결";
        type = HandsType.ValueCondition;
        description =
            "발동 조건: 이번 턴 최종 공격 횟수가 4회 이상일 때\n" +
            "효과: 공격 수치를 10만큼 추가로 획득한다.";
    }

    public override bool CheckCondition(Player player, Monster enemy)
    {
        int totalAttackCount = player.attackCount + player.tempAttackCount;
        bool condition = (totalAttackCount >= 4);
        Debug.Log("[속전속결] CheckCondition: (attackCount + tempAttackCount) >= 4 => " + condition + " (최종 공격 횟수: " + totalAttackCount + ")");
        if (condition)
        {
            return true;
        }
        return false;
    }

    public override void ExecuteEffect(Player player, Monster enemy)
    {
        Debug.Log("[속전속결] ExecuteEffect: attackValue += 10;");

        player.attackValue += 10;
        Debug.Log("[속전속결] 공격 수치 +10 (현재 공격 수치: " + player.attackValue + ")");
    }
}
