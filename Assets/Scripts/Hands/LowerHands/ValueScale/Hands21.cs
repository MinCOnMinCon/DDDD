using UnityEngine;

[CreateAssetMenu(fileName = "Hands21", menuName = "Hands/Instant/Hands21")]
public class Hands21 : Hands
{
    private void Awake()
    {
        handsName = "자기 실현적 예언";
        type = HandsType.Instant;
        description =
            "발동 조건: 6 눈 주사위가 3개 이상이고, 패널티 주사위를 2개 이상 보유하고 있을 때\n" +
            "효과: 모든 운명 토큰을 패널티 주사위로 교체하고, 교체된 운명 토큰 1개당 공격 수치를 3만큼 증가시킨다.";
    }

    public override bool CheckCondition(Player player, Monster enemy)
    {
        bool condition = (player.diceResults[6] >= 3 && player.penaltyDiceCount >= 2);
        Debug.Log("[자기 실현적 예언] CheckCondition: diceResults[6] >= 3 && penaltyDiceCount >= 2 => " + condition);
        if (condition)
        {
            return true;
        }
        return false;
    }

    public override void ExecuteEffect(Player player, Monster enemy)
    {
        int converted = player.destinyTokenCount;
        Debug.Log("[자기 실현적 예언] ExecuteEffect: converted = destinyTokenCount(" + converted + "); penaltyDiceCount += converted; destinyTokenCount = 0; attackValue += converted * 3;");

        if (converted > 0)
        {
            player.penaltyDiceCount += converted;
            player.destinyTokenCount = 0;
            int bonusAttack = converted * 3;
            player.attackValue += bonusAttack;
            Debug.Log("[자기 실현적 예언] 운명 토큰 " + converted + "개를 패널티로 변환, 공격 수치 +" + bonusAttack + " (현재 공격 수치: " + player.attackValue + ", 패널티 주사위: " + player.penaltyDiceCount + ")");
        }
        else
        {
            Debug.Log("[자기 실현적 예언] 변환할 운명 토큰이 없어 효과가 적용되지 않았습니다.");
        }
    }
}
