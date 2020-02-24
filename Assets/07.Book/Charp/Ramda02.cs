using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ramda02 : MonoBehaviour
{
    delegate void MyDelegate<T>(T a, T b);
    MyDelegate<string> myDelegate;

    private void Start()
    {
        myDelegate += (string a, string b) => { print(b); print(a); };
        myDelegate("Im here" ,"Man ");

    }
}
