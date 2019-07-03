using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ani : MonoBehaviour
{
    private Animation anim;

    private void Start()
    {
        anim = GetComponent<Animation>();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            
            // sekisuri 2019-7-4 처음 애니메이션이 끝나고 실행이된다.
            anim.PlayQueued("cube2");
           
           

            
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            // sekisuri 2019-7-4 큐브2 애니메이션을 실행한다
            anim.Play("cube2");
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            // sekisuri 2019-7-4 큐브1과 동시에 실행이 된다
            anim.Blend("cube2");
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            // sekisuri 2019-7-4 큐브1이 자연스럽게 사라지고 큐브2가 실행이 된다.
            anim.CrossFade("cube2");
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (!anim.IsPlaying("cube2"))
            {// sekisuri 2019-7-4 큐브2가 실행이 되지 않았으면 실행해라
                anim.Play("cube2");
            }
        }
    }
}
