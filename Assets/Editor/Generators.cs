using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Generators : Editor
{
    class HandsData
    {
        public int key;
        public string name;
        public string condition;
        public string effect;
        public Hands.HandsType type;

        public HandsData(int key, string name, string condition, string effect, Hands.HandsType type)
        {
            this.key = key;
            this.name = name;
            this.condition = condition;
            this.effect = effect;
            this.type = type;
        }
    }

    [MenuItem("Tools/Generate All Hands")]
    public static void GenerateAll()
    {
        string folder = "Assets/Scripts/Hands/LowerHands";
    

        List<HandsData> list = new List<HandsData>();

        // -----------------------------
        // 1️⃣ Sub (1~6)
        // -----------------------------
        list.Add(new HandsData(1, "최선의 방어는..",
            "눈 2 >= 2 or 눈 3 >= 2",
            "눈 2 조건 충족 -> 눈 4 +1\n눈 3 조건 충족 -> 눈 5 +1",
            Hands.HandsType.Sub));

        list.Add(new HandsData(2, "공격적 방어",
            "눈 4 >= 2 or 눈 5 >= 2",
            "눈 4 조건 충족 -> 눈 2 +1\n눈 5 조건 충족 -> 눈 3 +1",
            Hands.HandsType.Sub));

        list.Add(new HandsData(3, "파멸적 운명",
            "눈 1 >= 3",
            "눈 6 +1, 운명 토큰 +1",
            Hands.HandsType.Sub));

        list.Add(new HandsData(4, "끝없는 파멸",
            "눈 1 >= 2",
            "패널티 주사위 +1",
            Hands.HandsType.Sub));

        list.Add(new HandsData(5, "요새",
            "눈 2 >= 2 or 눈 3 >= 2",
            "눈 2 조건 충족 -> 눈 2 +1\n눈 3 조건 충족 -> 눈 3 +1",
            Hands.HandsType.Sub));

        list.Add(new HandsData(6, "앙 가르드",
            "눈 4 >= 2 or 눈 5 >= 2",
            "눈 4 조건 충족 -> 눈 4 +1\n눈 5 조건 충족 -> 눈 5 +1",
            Hands.HandsType.Sub));



        // -----------------------------
        // 2️⃣ Instant (7~20, 36, 37)
        // -----------------------------
        list.Add(new HandsData(7, "예언의 서막",
            "눈 2 >= 2",
            "적 예언 +2, 방어 +2",
            Hands.HandsType.Instant));

        list.Add(new HandsData(8, "운명의 스트레이트",
            "눈 1 >= 1 and 눈 2 >= 1 and 눈 3 >= 1 and 눈 4 >= 1 and 눈 5 >= 1",
            "운명 토큰 +3",
            Hands.HandsType.Instant));

        list.Add(new HandsData(9, "패널티 소멸",
            "패널티 주사위 >= 2",
            "패널티 주사위 2개 삭제, 체력 +5",
            Hands.HandsType.Instant));

        list.Add(new HandsData(10, "도박사의 보상",
            "눈 2 >= 1 and 눈 4 >= 1 and 눈 6 >= 1",
            "주사위 +1, 공격 +5, 방어 +5",
            Hands.HandsType.Instant));

        list.Add(new HandsData(11, "순환하는 운명",
            "눈 6 >= 2",
            "운명 토큰 +1",
            Hands.HandsType.Instant));

        list.Add(new HandsData(12, "운명의 제어",
            "운명 토큰 >= 3",
            "운명 토큰 1개 소모 -> 공격 +7, 방어 +7",
            Hands.HandsType.Instant));

        list.Add(new HandsData(13, "전광석화",
            "눈 4 + 눈 5 >= 3",
            "공격 횟수 +1",
            Hands.HandsType.Instant));

        list.Add(new HandsData(14, "무력 증강",
            "눈 5 >= 3",
            "공격 + (눈 5 * 5)",
            Hands.HandsType.Instant));

        list.Add(new HandsData(15, "광전사",
            "눈 5 >= 1 and 눈 1 >= 2",
            "공격 횟수 +2, 패널티 주사위 +2",
            Hands.HandsType.Instant));

        list.Add(new HandsData(17, "연격",
            "눈 4 + 눈 5 >= 4",
            "공격 횟수 + ((눈 4 + 눈 5) / 3)",
            Hands.HandsType.Instant));

        list.Add(new HandsData(18, "둠해머",
            "패널티 주사위 >= 3",
            "공격 횟수 +2, 패널티 주사위 -2",
            Hands.HandsType.Instant));

        list.Add(new HandsData(19, "파멸",
            "패널티 주사위 >= 6",
            "공격 +70, 패널티 주사위 -5",
            Hands.HandsType.Instant));

        list.Add(new HandsData(20, "현실 왜곡",
            "눈 2 + 눈 3 >= 4",
            "적 예언 +5, 이번 턴 주사위 +1",
            Hands.HandsType.Instant));

        list.Add(new HandsData(36, "행운의 가속",
            "눈 6 >= 4",
            "주사위 +2",
            Hands.HandsType.Instant));

        list.Add(new HandsData(37, "다이스의 연금술",
            "눈 2 >= 1 and 눈 3 >= 1 and 눈 4 >= 1 and 눈 5 >= 1",
            "공격 +9, 방어 +9",
            Hands.HandsType.Instant));



        // -----------------------------
        // 3️⃣ ValueScale (16, 21~28)
        // -----------------------------
        list.Add(new HandsData(16, "철갑무사",
            "눈 4 >= 2 and 눈 3 >= 1",
            "공격 횟수 * 4 만큼 방어 획득",
            Hands.HandsType.ValueScale));

        list.Add(new HandsData(21, "자기 실현적 예언",
            "눈 6 >= 3 and 패널티 주사위 >= 2",
            "모든 운명 토큰을 패널티 주사위로 변환 -> (변환 수 * 3) 공격 증가",
            Hands.HandsType.ValueScale));

        list.Add(new HandsData(22, "속죄의 폭풍",
            "패널티 주사위 >= 3 and (눈 4 >= 1 or 눈 5 >= 1)",
            "패널티 주사위 * 5 만큼 공격 증가, 패널티 주사위 -1",
            Hands.HandsType.ValueScale));

        list.Add(new HandsData(24, "피의 연회",
            "패널티 주사위 >= 3 and (눈 2 >= 1 or 눈 3 >= 1)",
            "공격의 20% 만큼 체력 회복",
            Hands.HandsType.ValueScale));

        list.Add(new HandsData(25, "파상 공세",
            "눈 4 >= 3",
            "공격 / 8 만큼 공격 횟수 증가",
            Hands.HandsType.ValueScale));

        list.Add(new HandsData(26, "흡수 타격",
            "눈 3 >= 1 and 눈 4 >= 1",
            "공격 횟수 * 4 만큼 체력 회복",
            Hands.HandsType.ValueScale));

        list.Add(new HandsData(27, "고통의 예언",
            "눈 4 >= 1 and 눈 5 >= 1",
            "공격 * 0.1 만큼 적에게 예언 부여",
            Hands.HandsType.ValueScale));

        list.Add(new HandsData(28, "신속의 예언",
            "눈 3 >= 1 and 눈 4 >= 1 and 눈 5 >= 1",
            "공격 횟수 * 2 만큼 적에게 예언 부여",
            Hands.HandsType.ValueScale));



        // -----------------------------
        // 4️⃣ ValueCondition (29~34)
        // -----------------------------
        list.Add(new HandsData(29, "운명 조작",
            "예언 >= 6 and 눈 6 >= 1",
            "운명 토큰 +1, 방어 +5",
            Hands.HandsType.ValueCondition));

        list.Add(new HandsData(30, "치유의 징조",
            "예언 >= 9 and 눈 2 >= 1",
            "체력 +7, 방어 +6",
            Hands.HandsType.ValueCondition));

        list.Add(new HandsData(31, "예지된 방어",
            "예언 >= 10 and 눈 3 >= 1",
            "방어 +15",
            Hands.HandsType.ValueCondition));

        list.Add(new HandsData(32, "예언 폭발",
            "예언 >= 11 and 눈 1 >= 1",
            "예언 * 2 만큼 공격 수치 증가",
            Hands.HandsType.ValueCondition));

        list.Add(new HandsData(33, "예언 : 죽음",
            "예언 >= 15 and (눈 4 >= 2 or 눈 5 >= 2)",
            "적 예언 초기화, 공격 +40",
            Hands.HandsType.ValueCondition));

        list.Add(new HandsData(34, "속전속결",
            "공격 횟수 >= 4",
            "공격 +10",
            Hands.HandsType.ValueCondition));


        // -----------------------------
        // ⭐ 실제 생성 파트 ⭐
        // -----------------------------
        foreach (var h in list)
        {
            Hands asset = ScriptableObject.CreateInstance<Hands>();
            asset.handsName = h.name;
            asset.description = h.condition + "\n" + h.effect;
            asset.type = h.type;
            asset.key = h.key;

            string path = $"{folder}/Hands_{h.key}.asset";
            AssetDatabase.CreateAsset(asset, path);
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        Debug.Log("All Hands ScriptableObjects Generated!");
    }
}
