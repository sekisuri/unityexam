using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
/*
* @author sekisuri
* http://ottcat.com
*/
public class ViewTap : MonoBehaviour 
{
    public GameObject[] mDamages;
    int i = 0;
    //    Action onTap = () => { }; // sekisuri 2019-6-15 탭을 했을 때 이벤트 처리

    //    private void Start()
    //    {

    //#if true
    //        Debug.Log("ViewTap Start");
    //#endif

    //    }

    //    // sekisuri 2019-6-15 탭 리스너 등록
    //    public void AddListenerOnTap(Action action)
    //    {
    //        onTap += action;
    //    }

    //    // EventTriggerからTap時によばれる
    //    public void OnTap()
    //    {

    //#if true
    //        Debug.Log("before OnTap");
    //#endif

    //        onTap();
    //    }


    // sekisuri 2019-6-15 Start <--
    // 이벤트 트리거를 사용해 클릭 처리를 할려고 했으나 잘 안되서 OnMouseDown()으로 처리
    // --> End sekisuri  
    private void OnMouseDown()
    {

        if(i < 4)
        {
            mDamages[i].GetComponent<Text>().text = i.ToString();
            mDamages[i].GetComponent<Animation>().Play();
            i++;
        }
        else
        {
            i = 0;
        }
        

    }
}
