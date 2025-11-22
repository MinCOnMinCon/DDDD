using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DB/HandsDatabase")]
public class HandsDatabase : ScriptableObject
{
    public List<Hands> handsList;
}