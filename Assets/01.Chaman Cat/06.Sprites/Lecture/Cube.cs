using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{

    Vector3 rotation;
    private void Start()
    {
        rotation = this.transform.eulerAngles;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Rotate(new Vector3(90, 0, 0) * Time.deltaTime);
        }
    }
}
