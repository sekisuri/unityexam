using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamCorutine : MonoBehaviour
{

    Coroutine myco1;
    Coroutine myco2;
    private IEnumerator myCoroutine;
   IEnumerator LoopA()
    {
        for( int i = 0; i < 100; i++)
        {
            print("i의 값 = " + i);
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator LoopB()
    {
        for (int x = 0; x < 100; x++)
        {
            print("x의 값 = " + x);
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator LoopC()
    {
        for (int y = 0; y < 100; y++)
        {
            print("y의 값 = " + y);
            yield return new WaitForSeconds(1f);
        }
    }
    private void Start()
    {
        myco1 = StartCoroutine(LoopA());
        myco2 = StartCoroutine(LoopB());
        StartCoroutine(myCoroutine);

        StartCoroutine(Stooop());
    }
    IEnumerator Stooop()
    {
        yield return new WaitForSeconds(2f);
        StopCoroutine(myco1);
        yield return new WaitForSeconds(2f);
        StopCoroutine(myco2);
    }
}
