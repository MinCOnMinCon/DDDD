using UnityEngine;

[CreateAssetMenu(fileName = "Hands37", menuName = "Hands/Instant/Hands37")]
public class Hands37 : Hands
{
    private void Awake()
    {
        handsName = "다이스의 연금술";
        type = HandsType.Instant;
        description =
            "발동 조건: 2, 3, 4, 5 눈 주사위가 각각 1개 이상 나왔을 때\n" +
            "효과: 공격 수치와 방어 수치를 각각 7만큼 즉시 증가시킨다.";
    }

    public override bool CheckCondition(Player player, Monster enemy)
    {
        bool condition =
            (player.diceResults[2] >= 1 &&
             player.diceResults[3] >= 1 &&
             player.diceResults[4] >= 1 &&
             player.diceResults[5] >= 1);
        Debug.Log("[다이스의 연금술] CheckCondition: diceResults[2..5] 각각 >= 1 => " + condition +
                  " (2: " + player.diceResults[2] + ", 3: " + player.diceResults[3] + ", 4: " + player.diceResults[4] + ", 5: " + player.diceResults[5] + ")");
        if (condition)
        {
            return true;
        }
        return false;
    }

    public override void ExecuteEffect(Player player, Monster enemy)
    {
        Debug.Log("[다이스의 연금술] ExecuteEffect: attackValue += 9; defenseValue += 9;");

        player.attackValue += 9;
        player.defenseValue += 9;
        Debug.Log("[다이스의 연금술] 공격 수치 +9, 방어 수치 +9 (현재 공격: " + player.attackValue + ", 현재 방어: " + player.defenseValue + ")");
    }
}
