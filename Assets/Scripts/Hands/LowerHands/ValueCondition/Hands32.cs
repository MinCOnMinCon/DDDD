using UnityEngine;

[CreateAssetMenu(fileName = "Hands32", menuName = "Hands/ValueCondition/Hands32")]
public class Hands32 : Hands
{
    private void Awake()
    {
        handsName = "예언 폭발";
        type = HandsType.ValueCondition;
        description =
            "발동 조건: 적의 예언 수치가 11 이상이고, 1 눈 주사위가 1개 이상 나왔을 때\n" +
            "효과: 적의 주사위 하나를 제거한다.";
    }

    public override bool CheckCondition(Player player, Monster enemy)
    {
        bool condition = (enemy.predictionValue >= 11 && player.diceResults[1] >= 1);
        Debug.Log("[예언 폭발] CheckCondition: enemy.predictionValue >= 11 && diceResults[1] >= 1 => " + condition + " (적 예언: " + enemy.predictionValue + ", 1 눈 개수: " + player.diceResults[1] + ")");
        if (condition)
        {
            return true;
        }
        return false;
    }

    public override void ExecuteEffect(Player player, Monster enemy)
    {
        Debug.Log("[예언 폭발] ExecuteEffect: 적의 주사위 하나 제거 시도");

        int removedFace = -1;
        for (int face = 6; face >= 1; face--)
        {
            if (enemy.diceResults[face] > 0)
            {
                enemy.diceResults[face] -= 1;
                removedFace = face;
                break;
            }
        }

        if (removedFace != -1)
        {
            Debug.Log("[예언 폭발] 적의 " + removedFace + " 눈 주사위를 1개 제거했습니다.");
        }
        else
        {
            Debug.Log("[예언 폭발] 제거할 수 있는 적 주사위가 없습니다.");
        }
    }
}
