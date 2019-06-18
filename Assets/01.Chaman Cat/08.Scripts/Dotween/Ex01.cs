using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;
/*
* @author sekisuri
* http://ottcat.com
*/
public class Ex01 : MonoBehaviour 
{


    [Button(ButtonSizes.Large)]
    public void Tween01()
    {
        transform.DOSpiral(1, Vector3.forward, SpiralMode.ExpandThenContract, 1, 10);
    }


}
