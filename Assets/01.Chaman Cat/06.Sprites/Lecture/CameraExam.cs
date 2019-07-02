using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraExam : MonoBehaviour
{
    [SerializeField]
    private GameObject go_Target;

    [SerializeField]
    private float speed;

    private Vector3 difValue;

    private void Start()
    {
        difValue = transform.position - go_Target.transform.position;
        difValue = new Vector3(Mathf.Abs(difValue.x), Mathf.Abs(difValue.y), Mathf.Abs(difValue.z));

    }

    private void Update()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, go_Target.transform.position + difValue, speed);
    }
}
