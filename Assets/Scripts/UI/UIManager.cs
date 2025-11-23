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
    private GameObject gameoverUI;
    
    private void Awake()
    {
        startUI.SetActive(true);
        storyUI.SetActive(false);
        combatUI.SetActive(false);
        gameoverUI.SetActive(false);
        
    }
    
        

    public void CombatConversion(int sceneNum)
    {

        storyUI.SetActive(false);
        combatUI.SetActive(true);
        if (sceneNum == 0)
        {
            PlayerManager.instance.SpawnPlayer();
        }
        LogManager.logManager.ResetLog();
        MonsterManager.instance.SpawnMonster(sceneNum);
        PlayerManager.instance.UpdatePlayer();
        
    }

    public void StoryConversion()
    {
        combatUI.SetActive(false);
        startUI.SetActive(false);
        storyUI.SetActive(true);
        
        
    }
    public void StartConversion()
    {
    
        startUI.SetActive(true);
        
        storyUI.SetActive(false);
        gameoverUI.SetActive(false);
    }
    public void GameoverConversion(bool playerDied)
    {
        combatUI.SetActive(false);
        storyUI.SetActive(false);
        storyUI.GetComponent<StoryTextManager>().ResetStory();
        if (MonsterManager.instance.isMonsterExisted()) MonsterManager.instance.DestroyMonster();
        if (PlayerManager.instance.isPlayerExisted()) PlayerManager.instance.DestroyPlayer();
        gameoverUI.GetComponent<GameOverUI>().SetGameoverText(playerDied);
        gameoverUI.SetActive(true);

    }

}
