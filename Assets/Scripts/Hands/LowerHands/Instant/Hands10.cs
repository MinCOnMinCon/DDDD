using UnityEngine;

[CreateAssetMenu(fileName = "Hands10", menuName = "Hands/Instant/Hands10")]
public class Hands10 : Hands
{
    private void Awake()
    {
        handsName = "도박사의 보상";
        type = HandsType.Instant;
        description =
            "발동 조건: 2, 4, 6 눈 주사위가 각각 1개 이상일 때\n" +
            "효과: 주사위를 1개 추가로 획득하고, 공격 수치와 방어 수치를 각각 5만큼 증가시킨다.";
    }

    public override bool CheckCondition(Player player, Monster enemy)
    {
        bool condition =
            player.diceResults[2] >= 1 &&
            player.diceResults[4] >= 1 &&
            player.diceResults[6] >= 1;

        Debug.Log("[도박사의 보상] CheckCondition: player.diceResults[2] >= 1 && player.diceResults[4] >= 1 && player.diceResults[6] >= 1 => " + condition);
        if (condition)
        {
            return true;
        }
        return false;
    }

    public override void ExecuteEffect(Player player, Monster enemy)
    {
        Debug.Log("[도박사의 보상] ExecuteEffect: player.tempDiceCount += 1; player.attackValue += 5; player.defenseValue += 5;");

        player.tempDiceCount += 1;
        player.attackValue += 5;
        player.defenseValue += 5;
        Debug.Log("[도박사의 보상] 추가 주사위 +1, 공격 +5, 방어 +5");
    }
}
