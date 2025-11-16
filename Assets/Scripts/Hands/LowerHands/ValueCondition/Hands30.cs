using UnityEngine;

[CreateAssetMenu(fileName = "Hands30", menuName = "Hands/ValueCondition/Hands30")]
public class Hands30 : Hands
{
    private void Awake()
    {
        handsName = "치유의 징조";
        type = HandsType.ValueCondition;
        description =
            "발동 조건: 적의 예언 수치가 9 이상이고, 2 눈 주사위가 1개 이상 나왔을 때\n" +
            "효과: 체력을 7만큼 회복하고, 방어 수치를 6만큼 증가시킨다.";
    }

    public override bool CheckCondition(Player player, Monster enemy)
    {
        bool condition = (enemy.predictionValue >= 9 && player.diceResults[2] >= 1);
        Debug.Log("[치유의 징조] CheckCondition: enemy.predictionValue >= 9 && diceResults[2] >= 1 => " + condition + " (적 예언: " + enemy.predictionValue + ")");
        if (condition)
        {
            return true;
        }
        return false;
    }

    public override void ExecuteEffect(Player player, Monster enemy)
    {
        Debug.Log("[치유의 징조] ExecuteEffect: health += 7; defenseValue += 6;");

        player.health += 7;
        player.defenseValue += 6;
        Debug.Log("[치유의 징조] 체력 +7 (현재 체력: " + player.health + "), 방어 수치 +6 (현재 방어 수치: " + player.defenseValue + ")");
    }
}
