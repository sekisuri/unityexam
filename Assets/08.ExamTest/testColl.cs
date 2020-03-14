using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testColl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

#if true
        Debug.Log("On Collision");
#endif

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

#if true
        Debug.Log("On Trigger");
#endif

    }
}
