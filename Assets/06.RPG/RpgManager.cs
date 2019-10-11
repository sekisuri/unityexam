using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RpgManager : MonoBehaviour
{

    public RpgTalkManger talkManager;
    public GameObject talkPanel;
    public Text TalkText;
    private GameObject scanObject;
    public bool isAction;
    public int talkIndex = 0;

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
        Debug.Log("talk index : " + talkIndex);
#endif

        Talk(objData.id, objData.isNpc);

    }

    public void CloseTalk()
    {
        talkPanel.SetActive(false);

    }
    void Talk(int id , bool isNpc)
    {
        string talkData = talkManager.GetTalk(id, talkIndex);
       
        if(talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            CloseTalk();
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
        talkIndex++;
    }
}
