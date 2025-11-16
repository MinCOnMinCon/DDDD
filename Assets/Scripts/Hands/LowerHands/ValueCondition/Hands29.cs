using UnityEngine;

[CreateAssetMenu(fileName = "Hands29", menuName = "Hands/ValueCondition/Hands29")]
public class Hands29 : Hands
{
    private void Awake()
    {
        handsName = "운명 조작";
        type = HandsType.ValueCondition;
        description =
            "발동 조건: 적의 예언 수치가 6 이상이고, 6 눈 주사위가 1개 이상 나왔을 때\n" +
            "효과: 운명 토큰을 1개 획득하고, 방어 수치를 5만큼 증가시킨다.";
    }

    public override bool CheckCondition(Player player, Monster enemy)
    {
        bool condition = (enemy.predictionValue >= 6 && player.diceResults[6] >= 1);
        Debug.Log("[운명 조작] CheckCondition: enemy.predictionValue >= 6 && diceResults[6] >= 1 => " + condition + " (적 예언: " + enemy.predictionValue + ")");
        if (condition)
        {
            return true;
        }
        return false;
    }

    public override void ExecuteEffect(Player player, Monster enemy)
    {
        Debug.Log("[운명 조작] ExecuteEffect: destinyTokenCount += 1; defenseValue += 5;");

        player.destinyTokenCount += 1;
        player.defenseValue += 5;
        Debug.Log("[운명 조작] 운명 토큰 +1 (현재: " + player.destinyTokenCount + "), 방어 수치 +5 (현재 방어 수치: " + player.defenseValue + ")");
    }
}
