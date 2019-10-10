using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RpgManager : MonoBehaviour
{

    public GameObject talkPanel;
    public Text TalkText;
    public GameObject scanObject;
    public bool isAction;
    public int talkIndex;

    public void Action(GameObject scanObj)
    {
       
        isAction = true;
        scanObject = scanObj;
        TalkText.text = "이것의 이름은 " + scanObject.name + "이라고 한다.";
        talkPanel.SetActive(true);

    }

    public void CloseTalk()
    {
        talkPanel.SetActive(false);

    }
    void Talk(int id , bool isNpc)
    {
        //    string talkData = RpgTalkManger.GetTalk(id, talkIndex);
        string talkData ="";
        if(talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            return;
        }
        if (isNpc)
        {
            TalkText.text = talkData;
        }
        else
        {
            TalkText.text = talkData;
        }
        isAction = true;
        talkIndex++;
    }
}
