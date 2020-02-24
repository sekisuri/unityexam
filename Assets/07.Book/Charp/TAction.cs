using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TAction : MonoBehaviour
{
    delegate string MyDelegate<T1, T2>(T1 a, T2 b);
    MyDelegate<int, int> myDelegate;

    Action<int, int> myDelegate2;

    Func<int, int, string> myDelegate3;

    private void Start()
    {
        myDelegate3 = (int a, int b) =>
        {
            int sum = a + b;
            return sum + "이 리턴되었습니다.";
        };

        print(myDelegate3(3, 5));
    }
}
