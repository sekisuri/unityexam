using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamOnEnable01 : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("I'm here Awake");
    }

    private void OnEnable()
    {
        Debug.Log("I'm here OnEnable");
    }
    private void OnDisable()
    {
        Debug.Log("I'm here OnDisable");
    }
    private void Start()
    {
        Debug.Log("I'm here Start");
    }

   
}
