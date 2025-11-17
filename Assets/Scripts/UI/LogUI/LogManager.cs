using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class LogEvent
{
    public static Action<String> onLog;
}
public class LogManager : MonoBehaviour
{
    public static LogManager logManager;
 
    [Header("UI Objects")]
    [SerializeField]
    private RectTransform content;
    [SerializeField]
    private GameObject logPrefab;
    [SerializeField]
    private int maxLogs = 9;


    private ScrollRect scrollRect;
    private List<GameObject> logs = new List<GameObject>();

    private void Awake()
    {
        logManager = this;
        scrollRect = GetComponentInChildren<ScrollRect>();
        Debug.Log($"{scrollRect.name}");
    }
    private void OnEnable()
    {
        LogEvent.onLog += AddLog;
    }
    private void OnDisable()
    {
        LogEvent.onLog -= AddLog;
    }
    private void AddLog(string msg)
    {
        GameObject newLog = Instantiate(logPrefab, content);
        newLog.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = msg;

        logs.Add(newLog);

        if(logs.Count > maxLogs)
        {
            Destroy(logs[0]);
            logs.RemoveAt(0);
        }

        Canvas.ForceUpdateCanvases();
        scrollRect.verticalNormalizedPosition = 0f;
    }
}
