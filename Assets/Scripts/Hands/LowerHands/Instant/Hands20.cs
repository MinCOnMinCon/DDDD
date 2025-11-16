using UnityEngine;

[CreateAssetMenu(fileName = "Hands20", menuName = "Hands/Instant/Hands20")]
public class Hands20 : Hands
{
    private void Awake()
    {
        handsName = "현실 왜곡";
        type = HandsType.Instant;
        description =
            "발동 조건: 2, 3 눈 주사위의 총합이 4개 이상일 때\n" +
            "효과: 적에게 예언 수치를 5만큼 부여하고, 다음 턴에 굴릴 주사위 개수를 1개 증가시키는 보너스를 획득한다.";
    }

    public override bool CheckCondition(Player player, Monster enemy)
    {
        int sum = player.diceResults[2] + player.diceResults[3];
        bool condition = sum >= 4;
        Debug.Log("[현실 왜곡] CheckCondition: (diceResults[2] + diceResults[3]) >= 4 => " + condition + " (총합: " + sum + ")");
        if (condition)
        {
            return true;
        }
        return false;
    }

    public override void ExecuteEffect(Player player, Monster enemy)
    {
        Debug.Log("[현실 왜곡] ExecuteEffect: enemy.predictionValue += 5; player.tempDiceCount += 1; // 다음 턴 주사위 +1 보너스용");

        enemy.predictionValue += 5;
        player.tempDiceCount += 1;
        Debug.Log("[현실 왜곡] 적 예언 +5, 다음 턴 주사위 +1 보너스 (현재 tempDiceCount: " + player.tempDiceCount + ")");
    }
}
