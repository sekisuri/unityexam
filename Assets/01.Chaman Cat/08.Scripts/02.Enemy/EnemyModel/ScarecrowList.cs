using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class ScarecrowList
{
    public int id; // モンスターのid
    public string name; // モンスターの名称
    public string assetName; // モンスター画像のアセット名
    public float hp;
    public int level;
}

class ScarecrowInfo
{
    static readonly List<ScarecrowList> info = new List<ScarecrowList>
    {// 허수아비 정보를 리스트에 저장한다
        new ScarecrowList() { id = 0, name = "허수아비00", assetName = "Scarecrow00", hp = 100, level = 1 },
        new ScarecrowList() { id = 1, name = "허수아비01", assetName = "Crab01", hp = 100, level = 1 },
        new ScarecrowList() { id = 2, name = "허수아비02", assetName = "Crab02", hp = 100, level = 1 },
        new ScarecrowList() { id = 3, name = "허수아비03", assetName = "Dragon01", hp = 100, level = 1 },
        new ScarecrowList() { id = 4, name = "허수아비04", assetName = "Dragon02", hp = 100, level = 1 },
        new ScarecrowList() { id = 5, name = "허수아비05", assetName = "Golem01", hp = 100, level = 1 },
        new ScarecrowList() { id = 6, name = "허수아비06", assetName = "Slime01", hp = 100, level = 1 },
        new ScarecrowList() { id = 7, name = "허수아비07", assetName = "Snake01", hp = 100, level = 1 },
    };


    static public ScarecrowList Find(int idx)
    {// 리스트에 저장된 허수아비 정보를 가져온다.
       
        ScarecrowList newScarecrow = new ScarecrowList();
        float rate = 1 + info[idx].level * 0.5f;

        newScarecrow.id = info[idx].id;
        newScarecrow.name = info[idx].name;
        newScarecrow.assetName = info[idx].assetName;
        newScarecrow.hp = info[idx].hp * rate;
        newScarecrow.level = info[idx].level;
        return newScarecrow;
        
    }
}
