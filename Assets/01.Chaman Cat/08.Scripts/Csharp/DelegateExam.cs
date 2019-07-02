using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* @author sekisuri
* http://ottcat.com
*/
delegate int MyDelegate(int a, int b);

class Calculator
{
    public int Plus(int a, int b)
    {
        return a + b;
    }

    public static int Minus(int a, int b)
    {
        return a - b;
    }
}
public class DelegateExam : MonoBehaviour 
{

    private void Start()
    {
        Calculator Calc = new Calculator();
        MyDelegate Callback;
        Callback = new MyDelegate(Calc.Plus);

#if true
        Debug.Log("Callback(3,4) : " + Callback(3,4));
#endif

        Callback = new MyDelegate(Calculator.Minus);

#if true
        Debug.Log("Callback(7,5) : " + Callback(5,7) );
#endif


    }

}
