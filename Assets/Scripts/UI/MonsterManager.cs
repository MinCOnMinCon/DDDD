using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public static MonsterManager instance;
    [SerializeField]
    private UIManager uiManager;
    

    [SerializeField]
    private List<GameObject> monsters = new List<GameObject>();
    public void SpawnMonster(int sceneNum)
    {
        
        Instantiate(monsters[sceneNum], transform);
    }
    public void DieMonster() 
    {
        uiManager.StoryConversion();
    }
    private void Awake()
    {
        instance = this;
       
    }
}
