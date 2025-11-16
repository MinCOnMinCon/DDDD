using UnityEngine;

[CreateAssetMenu(fileName = "Hands12", menuName = "Hands/Instant/Hands12")]
public class Hands12 : Hands
{
    private void Awake()
    {
        handsName = "운명의 제어";
        type = HandsType.Instant;
        description =
            "발동 조건: 운명 토큰을 3개 이상 보유하고 있을 때\n" +
            "효과: 운명 토큰을 1개 소모하여 공격 수치와 방어 수치를 각각 7만큼 증가시킨다.";
    }

    public override bool CheckCondition(Player player, Monster enemy)
    {
        bool condition = player.destinyTokenCount >= 3;
        Debug.Log("[운명의 제어] CheckCondition: player.destinyTokenCount >= 3 => " + condition);
        if (condition)
        {
            return true;
        }
        return false;
    }

    public override void ExecuteEffect(Player player, Monster enemy)
    {
        Debug.Log("[운명의 제어] ExecuteEffect: player.destinyTokenCount -= 1; player.attackValue += 7; player.defenseValue += 7;");

        player.destinyTokenCount -= 1;
        player.attackValue += 7;
        player.defenseValue += 7;
        Debug.Log("[운명의 제어] 운명 토큰 -1, 공격 +7, 방어 +7");
    }
}
