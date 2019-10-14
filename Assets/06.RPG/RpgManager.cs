using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RpgManager : MonoBehaviour
{

    public RpgTalkManger talkManager;
    public QuestManager questManager;


    public Animator AnitalkPanel;
    public Animator AniChange;
    public Image portraitImg;
    public TypeEffect TalkEffect;
    private GameObject scanObject;
    public bool isAction;
    private int talkIndex = 0;

    public Sprite prevPortrait;

    public void Action(GameObject scanObj)
    {

        AnitalkPanel.SetBool("isShow",true);

        isAction = true;
        scanObject = scanObj;
        //  TalkText.text = "이것의 이름은 " + scanObject.name + "이라고 한다.";
        ObjData objData = scanObject.GetComponent<ObjData>();

#if false
        Debug.Log("objData id : " + objData.id);
        Debug.Log("objData isNpc : " + objData.isNpc);
        Debug.Log("talkIndex : " + talkIndex);
#endif

        Talk(objData.id, objData.isNpc);

    }

    public void CloseTalk()
    {
        
        AnitalkPanel.SetBool("isShow",false);

    }
    void Talk(int id , bool isNpc)
    {

        int questTalkIndex = 0;
        string talkData = "";

        if (TalkEffect.isAnim)
        {
            TalkEffect.SetMsg("");
            return;
        }
        else
        {
            questTalkIndex = questManager.GetQuestTalkIndex(id);
            questTalkIndex += id;
            talkData = talkManager.GetTalk(questTalkIndex, talkIndex);
        }
        
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
            TalkEffect.SetMsg(talkData.Split(':')[0]); 
            portraitImg.sprite = talkManager.GetPortrait(id, int.Parse(talkData.Split(':')[1]));
            portraitImg.color = new Color(1, 1, 1, 1);

            if(prevPortrait != portraitImg.sprite)
            {
                AniChange.SetTrigger("doEffect");
                prevPortrait = portraitImg.sprite;
            }
        }
        else
        {
            TalkEffect.SetMsg(talkData);
            portraitImg.color = new Color(0, 0, 0, 0);
        }
        talkIndex++;
    }
}
