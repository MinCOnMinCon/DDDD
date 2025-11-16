using UnityEngine;

[CreateAssetMenu(fileName = "Hands7", menuName = "Hands/Instant/Hands7")]
public class Hands7 : Hands
{
    private void Awake()
    {
        handsName = "예언의 서막";
        type = HandsType.Instant;
        description =
            "발동 조건: 2 눈이 2개 이상일 때\n" +
            "효과: 적에게 예언 수치 2를 부여하고, 방어 수치를 2만큼 획득한다.";
    }

    public override bool CheckCondition(Player player, Monster enemy)
    {
        bool condition = player.diceResults[2] >= 2;
        Debug.Log("[예언의 서막] CheckCondition: player.diceResults[2] >= 2 => " + condition);
        if (condition)
        {
            return true;
        }
        return false;
    }

    public override void ExecuteEffect(Player player, Monster enemy)
    {
        Debug.Log("[예언의 서막] ExecuteEffect: enemy.predictionValue += 2; player.defenseValue += 2;");

        enemy.predictionValue += 2;
        player.defenseValue += 2;
        Debug.Log("[예언의 서막] 적 예언 +2, 방어 +2");
    }
}
