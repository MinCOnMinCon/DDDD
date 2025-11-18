using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartManager : MonoBehaviour
{
    [SerializeField]
    private UIManager uiManager;
    public void onButtonCilcked()
    {
        uiManager.StoryConversion();
    }
}
