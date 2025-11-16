using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class HandsUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private TMPro.TextMeshProUGUI handsName;

    private string description;
    
    // Start is called before the first frame update
    public void SetInfo(HandsManager.HandsInstance inst)
    {
        handsName.text = "- " + inst.hand.handsName;
        description = inst.hand.description;
    }

    public void SetActive(bool active)
    {
        if (active)
        {
            handsName.color = Color.yellow;
        }
        else
        {
            handsName.color = Color.white;
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        ToolTipManager.toolTipManager.ToolTipShow(handsName.text, description);

    }
    public void OnPointerExit(PointerEventData eventData)
    {
        ToolTipManager.toolTipManager.ToolTipHIde();
    }
   


}
