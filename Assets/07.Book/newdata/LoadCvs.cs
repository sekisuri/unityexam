using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCvs : MonoBehaviour
{
    public string all_data;
    public string[] data_list;

    private void Awake()
    {
        TextAsset TextF = (TextAsset)Resources.Load("gamedata") as TextAsset;
        all_data = TextF.text;
        data_list = all_data.Split('\n');
    }

    private void Start()
    {
        for (int i = 1; i < data_list.Length - 1; i++)
        {
            string[] splitedData = data_list[i].Split(',');
            Debug.Log(splitedData[0] + " " + int.Parse(splitedData[1]) + " " + int.Parse(splitedData[2]) + " " + int.Parse(splitedData[3]));
        }
    }
}
