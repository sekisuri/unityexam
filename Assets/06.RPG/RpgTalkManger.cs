using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RpgTalkManger : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;

    public Sprite[] portraitArray;
    private void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        GenerateData();

    }

    void GenerateData()
    {
        talkData.Add(1000, new string[] { "안녕?:0", "이 곳에 처음 왔구나?:1" });
        talkData.Add(2000, new string[] { "내이름은 엔피시이다:1 ","넌 누구야?:0" ,"여기에 잘왔다:2"  });
        talkData.Add(100, new string[] { "평범한 나무상자다." });
        talkData.Add(200, new string[] { "누군가 사용했던 흔적이 있는 책상이다." });

        portraitData.Add(1000 + 0, portraitArray[0]);
        portraitData.Add(1000 + 1, portraitArray[1]);
        portraitData.Add(1000 + 2, portraitArray[2]);
        portraitData.Add(1000 + 3, portraitArray[3]);

        portraitData.Add(2000 + 0, portraitArray[4]);
        portraitData.Add(2000 + 1, portraitArray[5]);
        portraitData.Add(2000 + 2, portraitArray[6]);
        portraitData.Add(2000 + 3, portraitArray[7]);


    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
        {
            return null;
        }
        else
        {
            return talkData[id][talkIndex];
        }
    }

    public Sprite GetPortrait(int id, int portraitIndex)
    {
        return portraitData[id + portraitIndex];
    }

}
