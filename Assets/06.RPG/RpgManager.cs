using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RpgManager : MonoBehaviour
{

    public RpgTalkManger talkManager;
    public QuestManager questManager;

    public GameObject talkPanel;
    public Image portraitImg;
    public Text TalkText;
    private GameObject scanObject;
    public bool isAction;
    private int talkIndex = 0;

    public void Action(GameObject scanObj)
    {

        talkPanel.SetActive(true);

        isAction = true;
        scanObject = scanObj;
        //  TalkText.text = "이것의 이름은 " + scanObject.name + "이라고 한다.";
        ObjData objData = scanObject.GetComponent<ObjData>();

#if true
        Debug.Log("objData id : " + objData.id);
        Debug.Log("objData isNpc : " + objData.isNpc);
        Debug.Log("talkIndex : " + talkIndex);
#endif

        Talk(objData.id, objData.isNpc);

    }

    public void CloseTalk()
    {
        
        talkPanel.SetActive(false);

    }
    void Talk(int id , bool isNpc)
    {
        int questTalkIndex = questManager.GetQuestTalkIndex(id);

#if true
        Debug.Log("talk id : " + id);
        Debug.Log("Index : " + questTalkIndex);
        Debug.Log("talk index : " + talkIndex);
#endif
        questTalkIndex += id;
        string talkData = talkManager.GetTalk(questTalkIndex, talkIndex);
        //string talkData = talkManager.GetTalk(id , talkIndex);



        if (talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            CloseTalk();
            return;
        }
        if (isNpc)
        {
            TalkText.text = talkData.Split(':')[0];
            portraitImg.sprite = talkManager.GetPortrait(id, int.Parse(talkData.Split(':')[1]));
            portraitImg.color = new Color(1, 1, 1, 1);
        }
        else
        {
            TalkText.text = talkData;
            portraitImg.color = new Color(0, 0, 0, 0);
        }
        talkIndex++;
    }
}
