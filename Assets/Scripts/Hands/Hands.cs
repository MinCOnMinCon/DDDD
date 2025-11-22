using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Hands/NewHands")]
public class Hands : ScriptableObject
{
    // 족보의 발동 순서를 결정하는 유형
    public enum HandsType { Instant, ValueScale, ValueCondition, NextTurn, Sub }
  
    [SerializeField] private string _handsName;
    [TextArea]
    [SerializeField] private string _description;
    [SerializeField] private HandsType _type;
    [SerializeField] private int _key;

    public string handsName { get => _handsName; set => _handsName = value; }
    public string description { get => _description; set => _description = value; }
    public HandsType type { get => _type; set => _type = value; }
    public int key { get => _key; set => _key = value; }

}