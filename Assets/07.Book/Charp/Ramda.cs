using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ramda : MonoBehaviour
{
    int a = 5;
    int b = 5;

    int sum;
    delegate void MyDelegate();
    MyDelegate myDelegate;
    
    private void Add()
    {
        sum = a + b;
    }

    //private void Print()
    //{
    //    print(sum);
    //}

    private void Back()
    {
        sum = 0;
    }

    private void Start()
    {
        myDelegate = Add;
        //myDelegate += delegate () { print(sum); };
        myDelegate += () => print(sum);
        myDelegate += Back;

        myDelegate();
    }
}
