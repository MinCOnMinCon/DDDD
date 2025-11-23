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
        FitToParent(curMonster.transform);
    }

    private void FitToParent(Transform child)
    {
        Vector3 parentSize = transform.GetComponent<SpriteRenderer>().bounds.size;
        Vector3 childSize = child.GetComponent<SpriteRenderer>().bounds.size;

        float scale = parentSize.x / childSize.x;
        child.localScale = new Vector3(scale, scale, 1);
    }

    public void DestroyMonster()
    {
        Destroy(curMonster);
    }
    public void DieMonster() 
    {
        uiManager.StoryConversion();
    }
    public bool isMonsterExisted()
    {
        return curMonster != null;
    }
    private void Awake()
    {
        instance = this;
       
    }
}
