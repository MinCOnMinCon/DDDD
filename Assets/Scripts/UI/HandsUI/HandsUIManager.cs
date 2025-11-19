using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsUIManager : MonoBehaviour
{
    [SerializeField] private Transform content;    
    [SerializeField] private GameObject handsUIPrefab;
    private HandsManager manager;

    // Start is called before the first frame update
    
    public void SetHandsManager(HandsManager inst)
    {
        manager = inst;
        manager.onHandsAdded += CreateUI;
        manager.onHandsExecuted += HighlightUI;
        manager.onHandsDelete += DeleteUI;
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
    private void DeleteUI(HandsManager.HandsInstance inst)
    {
        Destroy(inst.ui.gameObject);
    }
    private void HighlightUI(HandsManager.HandsInstance inst)
    {
  
        inst.ui.SetActive(true);
    }
}
