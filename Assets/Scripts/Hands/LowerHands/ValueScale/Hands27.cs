using UnityEngine;

[CreateAssetMenu(fileName = "Hands27", menuName = "Hands/ValueScale/Hands27")]
public class Hands27 : Hands
{
    private void Awake()
    {
        handsName = "고통의 예언";
        type = HandsType.ValueScale;
        description =
            "발동 조건: 4 눈 주사위와 5 눈 주사위가 각각 1개 이상 나왔을 때\n" +
            "효과: 현재 공격 수치의 10%만큼 적에게 예언 수치를 부여한다.";
    }

    public override bool CheckCondition(Player player, Monster enemy)
    {
        bool condition = (player.diceResults[4] >= 1 && player.diceResults[5] >= 1);
        Debug.Log("[고통의 예언] CheckCondition: diceResults[4] >= 1 && diceResults[5] >= 1 => " + condition);
        if (condition)
        {
            return true;
        }
        return false;
    }

    public override void ExecuteEffect(Player player, Monster enemy)
    {
        int bonus = Mathf.FloorToInt(player.attackValue * 0.1f);
        Debug.Log("[고통의 예언] ExecuteEffect: bonus = floor(attackValue * 0.1) = " + bonus + "; enemy.predictionValue += bonus;");

        enemy.predictionValue += bonus;
        Debug.Log("[고통의 예언] 적 예언 수치 +" + bonus + " (현재 적 예언 수치: " + enemy.predictionValue + ")");
    }
}
