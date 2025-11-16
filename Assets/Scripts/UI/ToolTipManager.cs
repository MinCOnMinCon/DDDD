using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ToolTipManager : MonoBehaviour
{
    public static ToolTipManager toolTipManager;
    [SerializeField] private GameObject toolTip;
    [SerializeField] private TMPro.TextMeshProUGUI description;

    // Start is called before the first frame update
    private void Awake()
    {
        toolTipManager = this;
        toolTip.SetActive(false);
    }

    public void ToolTipShow(string name, string des, Vector2 pos)
    {
        description.text = $"{name}\n"+$"{des}";
        toolTip.SetActive(true);
        toolTip.transform.position = pos;
    }

    public void ToolTipHIde()
    {
        Debug.Log("Aa");
        toolTip.SetActive(false);
    }
}
