using UnityEngine;

[CreateAssetMenu(fileName = "Hands31", menuName = "Hands/ValueCondition/Hands31")]
public class Hands31 : Hands
{
    private void Awake()
    {
        handsName = "예지된 방어";
        type = HandsType.ValueCondition;
        description =
            "발동 조건: 적의 예언 수치가 10 이상이고, 3 눈 주사위가 1개 이상 나왔을 때\n" +
            "효과: 이번 턴 방어 수치를 15만큼 증가시킨다.";
    }

    public override bool CheckCondition(Player player, Monster enemy)
    {
        bool condition = (enemy.predictionValue >= 10 && player.diceResults[3] >= 1);
        Debug.Log("[예지된 방어] CheckCondition: enemy.predictionValue >= 10 && diceResults[3] >= 1 => " + condition + " (적 예언: " + enemy.predictionValue + ", 3 눈 개수: " + player.diceResults[3] + ")");
        if (condition)
        {
            return true;
        }
        return false;
    }

    public override void ExecuteEffect(Player player, Monster enemy)
    {
        Debug.Log("[예지된 방어] ExecuteEffect: defenseValue += 15;");

        player.defenseValue += 15;
        Debug.Log("[예지된 방어] 방어 수치 +15 (현재 방어 수치: " + player.defenseValue + ")");
    }
}
