using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public static MonsterManager instance;
    [SerializeField]
    private UIManager uiManager;
    
    

    [SerializeField]
    private List<GameObject> monsters = new List<GameObject>();
    private GameObject curMonster;
    public void SpawnMonster(int sceneNum)
    {
        curMonster = Instantiate(monsters[sceneNum], transform);

    }
 
    public void DestroyMonster()
    {
        Destroy(curMonster);
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
