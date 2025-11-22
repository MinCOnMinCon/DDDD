using UnityEngine;
using UnityEditor;

public class HandsGenerator : EditorWindow
{
    [MenuItem("Tools/Generate Hands ScriptableObjects")]
    public static void GenerateHands()
    {


        Create(36, "행운의 가속",
            "6 ≥4\n주사위 +2",
            Hands.HandsType.Instant);

        Create(37, "다이스의 연금술",
            "2~5 각각 ≥1\n공격 +9, 방어 +9",
            Hands.HandsType.Instant);

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        Debug.Log("✔ 29~34번 Hands ScriptableObjects 생성 완료!");
        Debug.Log("✔ Hands ScriptableObjects 생성 완료!");
    }

    private static void Create(int key, string name, string desc, Hands.HandsType type)
    {
        Hands asset = ScriptableObject.CreateInstance<Hands>();

        asset.handsName = name;
        asset.description = desc;
        asset.type = type;
        asset.key = key;

        string safeName = name.Replace(" ", "_");
        string path = $"Assets/Scripts/Hands/LowerHands/Instant/Hands_{key}_{safeName}.asset";

        AssetDatabase.CreateAsset(asset, path);
    }
}
