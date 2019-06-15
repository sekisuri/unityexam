using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* @author sekisuri
* http://ottcat.com
*/
public class EventTest : MonoBehaviour 
{

    [SerializeField] ViewTap viewTap;


    private void Start()
    {

#if true
        Debug.Log("EventTest Start");
#endif

        viewTap.AddListenerOnTap(OnTap);
    }

    private void OnTap()
    {

#if true
        Debug.Log("OnTap Click");
#endif

    }
}
