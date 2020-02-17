using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRTest : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine("TestCoroutine");
    }

    IEnumerator TestCoroutine()
    {
        Debug.Log("코루틴 시작");
        yield return new WaitForSeconds(3.0f);
        Debug.Log("3초 후 빠져나감");
    }
}
