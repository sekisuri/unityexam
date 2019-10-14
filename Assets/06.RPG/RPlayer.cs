using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPlayer : MonoBehaviour
{
    public float Speed;

    RpgManager gameManager;
    Rigidbody2D rigid;
    float h;
    float v;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        gameManager = FindObjectOfType<RpgManager>();
    }
    private void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        rigid.velocity = new Vector2(h, v) * Speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
#if false
        Debug.Log(collision.gameObject.name + "와 접촉하다");
#endif 
        if(collision.gameObject.tag == "EndLine")
        {
            // 이게 왜 안되지?? collision.gameObject.GetComponent<RpgManager>().CloseTalk();
            gameManager.CloseTalk();
        }
        else
        {
            gameManager.Action(collision.gameObject);
        }
        
    }
}
