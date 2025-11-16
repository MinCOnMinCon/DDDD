using UnityEngine;

[CreateAssetMenu(fileName = "Hands33", menuName = "Hands/ValueCondition/Hands33")]
public class Hands33 : Hands
{
    private void Awake()
    {
        handsName = "예언 : 죽음";
        type = HandsType.ValueCondition;
        description =
            "발동 조건: 적의 예언 수치가 15 이상이고, 4 또는 5 눈 주사위가 2개 이상 나왔을 때\n" +
            "효과: 적의 예언 수치를 모두 제거하고, 공격 수치를 40만큼 증가시킨다.";
    }

    public override bool CheckCondition(Player player, Monster enemy)
    {
        int sum45 = player.diceResults[4] + player.diceResults[5];
        bool condition = (enemy.predictionValue >= 15 && sum45 >= 2);
        Debug.Log("[예언 : 죽음] CheckCondition: enemy.predictionValue >= 15 && (diceResults[4] + diceResults[5]) >= 2 => " + condition + " (적 예언: " + enemy.predictionValue + ", 4,5 합: " + sum45 + ")");
        if (condition)
        {
            return true;
        }
        return false;
    }

    public override void ExecuteEffect(Player player, Monster enemy)
    {
        int removedPrediction = enemy.predictionValue;
        Debug.Log("[예언 : 죽음] ExecuteEffect: enemy.predictionValue = 0; attackValue += 40; (제거된 예언 수치: " + removedPrediction + ")");

        enemy.predictionValue = 0;
        player.attackValue += 40;
        Debug.Log("[예언 : 죽음] 적 예언 수치 0으로 초기화, 공격 수치 +40 (현재 공격 수치: " + player.attackValue + ")");
    }
}
