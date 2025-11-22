 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ToolTipManager : MonoBehaviour
{

    public static ToolTipManager toolTipManager;
    [SerializeField] private GameObject toolTip;
    [SerializeField] private TMPro.TextMeshProUGUI description;
    private bool isShowed;

    private RectTransform toolTipRect;
    private RectTransform canvasRect;
    private Camera uiCam;

    // Start is called before the first frame update
    private void Awake()
    {
        toolTipManager = this;
        toolTip.SetActive(false);
        isShowed = false;

        toolTipRect = toolTip.GetComponent<RectTransform>();
        canvasRect = GetComponentInParent<Canvas>().GetComponent<RectTransform>();
        uiCam = GetComponentInParent<Canvas>().worldCamera;

    }

    public void ToolTipShow(string name, string des)
    {
        description.text = $"{name}\n"+$"{des}";
        isShowed = true;
        toolTip.SetActive(true);
        
    }

    public void ToolTipHIde()
    {
        isShowed = false;
        toolTip.SetActive(false);
    }

    private void Update()
    {
        if (isShowed)
        {
            Vector2 localPos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvasRect,
                Input.mousePosition,
                uiCam,
                out localPos
            );

            toolTipRect.anchoredPosition = localPos;
        }
    }
}
