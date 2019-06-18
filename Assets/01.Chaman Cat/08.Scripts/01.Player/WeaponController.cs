using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WeaponController : MonoBehaviour
{
    public BoxCollider2D mCollider;
    // 무기가 계속 날라가는 걸 막기위해 오브젝트를 만들어 충돌하면 무기 오브젝트를 파괴한다
    private GameObject endBox; 


    private void Start()
    {
        // 콜라이더를 가져온다
        mCollider = gameObject.GetComponent<BoxCollider2D>();
    }

    public void Shoot()
    {
        endBox = GameObject.Find("EndLine"); // 오브젝트를 가져온다.

        // 무기가 날아갈 위치를 지정한다.
        Vector2 randomPos = Random.insideUnitCircle * 0.2f;
        //  
        // sekisuri 20190408 transform.DOMove(monster.transform.position + new Vector3(randomPos.x, randomPos.y, 0), 1);
        // dotween를 사용해 무기를 날려보낸다.
        transform.DOMove(endBox.transform.position + new Vector3(randomPos.x, randomPos.y, 0), 1);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
#if false
        Debug.Log("tag Name: " + other.tag);
#endif
        if(other.tag == "Scarecrow")
        {
#if false
            Debug.Log("In Scarescrow");
#endif                
            // 무기가 허수아비와 충돌하면 데미지를 처리한다.
            other.GetComponent<ScarecrowController>().Hit();
            Destroy(gameObject); // 무기를 파괴한다
        }
        
        // sekisuri 20190408 endBox
        if (other.tag == "EndLine")
        { // 무기가 제한 오브젝트와 충돌하면 무기를 파괴한다.
            Destroy(gameObject);
        }
    }
}
