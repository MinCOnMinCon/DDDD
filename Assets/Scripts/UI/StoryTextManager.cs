using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StoryTextManager : MonoBehaviour
{
    // Start is called before the first frame update
    private TMPro.TextMeshProUGUI storyText;
    private List<string> text = new List<string>();
    private int curSceneNum = 0;
    private int curIndex = 0;
    [SerializeField]
    private UIManager uiManager;

    private void Awake()
    {
        storyText = GetComponentInChildren<TextMeshProUGUI>();
        
    }
    private void OnEnable()
    {
        storyText.text = "";
        text.Clear();
        curIndex = 0;
        switch (curSceneNum)
        {
            case 0:
                text.Add("... -멘!\n" + "위에서 엄청난 굉음이 울렸고, 그 소리에 당신은 눈을 뜹니다.");
                text.Add("당신의 주위에는 일곱개의 횃불이 일렁입니다.\n" + "눈 앞에는 7개의 봉인으로 잠겨있는 고서 한권이 보입니다.");
                text.Add("당신은 무언가에 홀린 것처럼 책에 손을 뻗습니다.");

                text.Add("당신이 손을 대자 책에 있는 봉인은 부서지고 횃불이 꺼지며 어두워졌습니다.");
                text.Add("다시 빛이 들자, 하얀 말을 탄 기사가 활시위를 당기며 당신에게 다가옵니다.");
                text.Add("\"오너라!\"");
                break;
            case 1:
                text.Add("당신이 기사를 쓰러트린 후, 당신은 처음에 있던 장소로 돌아왔습니다.");
                text.Add("이전과는 달리 한 횃불에 불이 꺼져있었습니다.");
                text.Add("고서에 남아있는 봉인은 6개, 당신은 다시 책에 손을 뻗습니다.");

                text.Add("봉인이 부서지고, 이번에는 붉은 말을 탄 기사가 대검을 휘두르며 당신에게 다가옵니다.");
                text.Add("\"오너라!\"");
                break;
            case 2:
                text.Add("두 번의 연전으로 힘겨웠던 당신은 숨을 거칠게 내뱉으며 고서에게 다가갑니다.");
                text.Add("고서에 남아있는 봉인은 5개, 당신은 다시 책에 손을 뻗습니다.");

                text.Add("봉인이 부서지고, 이번에는 검은 말을 탄 기사가 저울을 들고 무언갈 중얼거리며 다가옵니다.");
                text.Add("\"오너라!\"");
                break;
            case 3:
                text.Add("검을 잡은 손은 아려오지만, 당신은 어째선지 멈추면 안된다는 생각이 듭니다.");
                text.Add("횃불은 절반 가까이 꺼져있습니다. 이젠 남은 횃불은 4개, 당신은 책에 손을 뻗습니다.");

                text.Add("봉인이 부서지고, 이번에는 파란 말을 탄 기사가 대낫으로 생명을 수확하며 다가옵니다.");
                text.Add("\"오너라!\"");
                break;
            case 4:
                text.Add("당신은 더 이상 서있을 힘도 없어 바닥에 엎어졌습니다.");
                text.Add("힘을 다해 책을 향해 기어가지만 끝내 기가맥진하여 더 이상 가지 못했습니다.");
                text.Add("그 때, 5번째 횃불이 세차게 흔들리며 책에서 고통스러운 목소리가 울려퍼집니다.");
                text.Add("\"심판의 때는 언제 오는가!\"");
                text.Add("\"아직입니다.\"");
                text.Add("당신은 나지막이 말하는 목소리를 듣고 뒤를 돌아보니, 검은 옷을 입은 여자를 보았습니다.");
                text.Add("\"아직 운명이 부족하여, 지금은 아닙니다.\"");
                text.Add("그녀는 그렇게 말하고는 자신의 펜던트를 바라봅니다.\n" +
                    " 그녀의 옷차림은 전부 검었으나, 펜던트만큼은 새하얀 빛으로 빛나고 있습니다.");
                text.Add("하지만 그 빛은 희미하게 깜빡이며 언제든지 꺼질 것 같았습니다.");
                text.Add("\"하지만.. 조만간 올 겁니다.\"" + "그녀는 당신을 안아 올리며 말했습니다.");
                text.Add("\"그때까지는, 부디 무탈하시길\"");
                text.Add("당신은 천천히 눈을 감았습니다...");
                break;
        }
    }
    
    public void onButtonClicked()
    {
        if(curIndex < text.Count)
        {
            storyText.text = text[curIndex];
            curIndex++;
        }
        else
        {
            curSceneNum++;
            uiManager.CombatConversion(curSceneNum - 1);
            
        }


    }


}
