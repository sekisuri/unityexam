using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCube : MonoBehaviour
{

    private void Start()
    {
        StartCoroutine(CreateCoroutine());
    }

    IEnumerator CreateCoroutine()
    {
        while (true)
        {
            yield return null;
            GameObject t_object = ObjectPoolingManager.instance.GetQueue();
            t_object.transform.position = Vector3.zero;
        }
    }
}
