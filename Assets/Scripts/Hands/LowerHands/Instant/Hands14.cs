using UnityEngine;

[CreateAssetMenu(fileName = "Hands14", menuName = "Hands/Instant/Hands14")]
public class Hands14 : Hands
{
    private void Awake()
    {
        handsName = "무력 증강";
        type = HandsType.Instant;
        description =
            "발동 조건: 5 눈 주사위가 3개 이상 나왔을 때\n" +
            "효과: 이번 턴에 5 눈 주사위의 개수 × 5 만큼 공격 수치를 추가로 획득한다.";
    }

    public override bool CheckCondition(Player player, Monster enemy)
    {
        bool condition = player.diceResults[5] >= 3;
        Debug.Log("[무력 증강] CheckCondition: player.diceResults[5] >= 3 => " + condition);
        if (condition)
        {
            return true;
        }
        return false;
    }

    public override void ExecuteEffect(Player player, Monster enemy)
    {
        int bonus = player.diceResults[5] * 5;
        Debug.Log("[무력 증강] ExecuteEffect: player.attackValue += (player.diceResults[5] * 5); => +" + bonus);

        player.attackValue += bonus;
        Debug.Log("[무력 증강] 공격 수치 +" + bonus + " (현재 공격 수치: " + player.attackValue + ")");
    }
}
