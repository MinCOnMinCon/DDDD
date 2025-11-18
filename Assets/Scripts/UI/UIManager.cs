using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject storyUI;
    [SerializeField]
    private GameObject startUI;
    [SerializeField]
    private GameObject combatUI;
    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private void Awake()
    {
        startUI.SetActive(true);
        storyUI.SetActive(false);
        combatUI.SetActive(false);
        Player.SetActive(false);
    }
    public void CombatConversion(int sceneNum)
    {

        storyUI.SetActive(false);
        Player.SetActive(true);
        combatUI.SetActive(true);
        MonsterManager.instance.SpawnMonster(sceneNum);
        Player.GetComponent<Player>().UpdateEnemy();
        Player.GetComponent<Player>().UpdateIndicator();
    }

    public void StoryConversion()
    {
        combatUI.SetActive(false);
        startUI.SetActive(false);
        Player.SetActive(false);
        storyUI.SetActive(true);
        
    }
    
}
