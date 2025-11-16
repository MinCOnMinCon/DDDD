using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class HandsUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private TMPro.TextMeshProUGUI handsName;
    [SerializeField]
    private TMPro.TextMeshProUGUI description;
    
    // Start is called before the first frame update
    public void SetInfo(HandsManager.HandsInstance inst)
    {
        handsName.text = inst.hand.handsName;
        description.text = inst.hand.description;
    }

    public void SetActive(bool active)
    {
        if (active)
        {
            handsName.fontMaterial.SetFloat("_OutlineWidth", 0.25f);
            handsName.fontMaterial.SetColor("_OutlineColor", Color.yellow);
            description.fontMaterial.SetFloat("_OutlineWidth", 0.25f);
            description.fontMaterial.SetColor("_OutlineColor", Color.yellow);
        }
        else
        {
            handsName.fontMaterial.SetFloat("_OutlineWidth", 0f);
            handsName.fontMaterial.SetColor("_OutlineColor", Color.white);
            description.fontMaterial.SetFloat("_OutlineWidth", 0f);
            description.fontMaterial.SetColor("_OutlineColor", Color.white);
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        ToolTipManager.toolTipManager.ToolTipShow(handsName.text, description.text, Input.mousePosition);

    }
    public void OnPointerExit(PointerEventData eventData)
    {
        ToolTipManager.toolTipManager.ToolTipHIde();
    }
   


}
