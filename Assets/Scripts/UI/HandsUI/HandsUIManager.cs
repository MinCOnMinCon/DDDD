using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsUIManager : MonoBehaviour
{
    [SerializeField] private Transform content;    
    [SerializeField] private GameObject handsUIPrefab;
    [SerializeField] private HandsManager manager;

    // Start is called before the first frame update
    private void OnEnable()
    {
        manager.onHandsAdded += CreateUI;
        manager.onHandsExecuted += HighlightUI;
        Debug.Log("HandsUIManager Enabled");
    }
    
    private void CreateUI(HandsManager.HandsInstance inst)
    {
        GameObject obj = Instantiate(handsUIPrefab, content);
        HandsUI ui = obj.GetComponent<HandsUI>();
        Debug.Log("객체 생성 완료");
        ui.SetInfo(inst);
        ui.SetActive(false);

        inst.ui = ui;
    }
    private void HighlightUI(HandsManager.HandsInstance inst)
    {
        inst.ui.SetActive(true);
    }
}
