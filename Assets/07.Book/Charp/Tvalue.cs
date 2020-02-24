using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tvalue : MonoBehaviour
{
    void Print<T>(T value) 
    {
        print(value);
    }

    private void Start()
    {
        Print<string>("string abc");
        Print<float>(4.4f);
    }

}
