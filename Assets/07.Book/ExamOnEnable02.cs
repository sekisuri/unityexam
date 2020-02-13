using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamOnEnable02 : MonoBehaviour
{
    public GameObject exam01;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            exam01.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            exam01.SetActive(true);
        }
    }
}

