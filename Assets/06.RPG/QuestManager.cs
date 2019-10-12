using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questId;
    public int questActionInd;
    private Dictionary<int, QuestData> questList;

    private void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        GenerateData();
    }

    void GenerateData()
    {
        questList.Add(10,new QuestData("마을 사람들과 대화하기",new int[]{1000,2000}));
    }

    public int GetQuestTalkIndex(int id)
    {
        
        return questId;
    }
}
