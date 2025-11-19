using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private UIManager uiManager;
    [SerializeField]
    private TMPro.TextMeshProUGUI gameoverText;

    public void SetGameoverText(bool playerDied)
    {
        if (playerDied)
        {
            gameoverText.text = "GAME\nOVER";
        }
        else
        {
            gameoverText.text = "TO BE\nCONTINUED";
        }
    }
    public void onButtonCilcked()
    {
        uiManager.StartConversion();
    }
}
