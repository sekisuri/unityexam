using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScarecrowController : MonoBehaviour
{

    [SerializeField]
    Animator mAnimator; // 자신의 애니메이터를 참조할 변수
    [SerializeField]
    SpriteRenderer mSprite; // 허수아비 스프라이트
    Transform mHealthBar;    // 체력바
    public Collider2D mCollider; // 몬스터의 피격 설정을 위한 콜라이더

    public GameObject[] mDamages; // 데미지 애니메이션

    float mHp; // 허수아비 체력
    int mLevel; // 허수아비 레벨

    // sekisuri 20190608 몬스터의 상태
    public enum Status
    {
        Alive,
        Dead
    }
    [HideInInspector]
    public Status mStatus = Status.Alive;
    // Start is called before the first frame update
    void Start()
    {
        InitScarecrow(); // 허수아비 초기화
    }

    private void InitScarecrow()
    {
        mLevel = GameManager.instance.ScareLevel; // 현제 레벨
        
        // 현재 레벨에 맞는 허수아비 스프라이트를 가져온다.
        var sprite = Resources.Load<Sprite>(string.Format("Scarecrow/{0}", ScarecrowInfo.Find(mLevel).assetName));

#if false
        Debug.Log("Path : " + string.Format("Scarecrow/{0}", ScarecrowInfo.Find(level).assetName));
        Debug.Log("Sprite : " + sprite);
#endif


      
        mSprite.sprite = sprite; // 허수아비 스프라이트를 초기화 한다.
        
        mHp = ScarecrowInfo.Find(mLevel).hp; // 허수아비 체력을 초기화 한다.
        mHealthBar = transform.Find("HealthBar"); // 허수아비 체력 오브젝트

    }
   
    

    // sekisuri 201906 
    // 피격 당할 경우 데미지 처리와 애니메이션 처리
    public void Hit()
    {
        GameObject player = GameObject.Find("Player");
        PlayerController playercontrol = player.GetComponent<PlayerController>();
        int ran = 0;
        // sekisuri 201903 Start <-- 몬스터가 받는 데미지 (몬스터 체력바)
        int playerDamage; // 플레이어 데미지
        if (playercontrol.IsCritical) 
        {// 플레이어 데미지가 크리티컬이면
            playerDamage = playercontrol.GetRandomDamage() * 2;
            // sekisuri 2019-6-15 크리티컬이면 다섯번째 애니메이션을 실행한다.
            ran = 4;
        }
        else
        {
            playerDamage = playercontrol.GetRandomDamage();
            // sekisuri 2019-6-14 랜덤으로 정수를 생성해 데미지와 애니메이션을 보여준다.
            ran = Random.Range(0, 4);
        }

       
        // 데미지 메시지 텍스트 애니메이션 오브젝트에 저장한다.
        mDamages[ran].GetComponent<Text>().text = playerDamage.ToString();
        //mDamages[ran].GetComponent<Text>().color = Color.blue;

        // 텍스트 애니메이션 오브젝트를 플레이한다.
        mDamages[ran].GetComponent<Animation>().Play();
        // --> End sekisuri 201903 
        // 체력을 컨트롤한다.
        SetDamage(playerDamage);
#if true
            Debug.Log("Damage : " + playerDamage + "  Hp : " + mHp );
#endif

        mAnimator.SetTrigger("Damage"); //데미지를 받으면 애니메이션 보여준다.

        // sekisuri 20190608 Start <--
        // 허수아비 사망처리
        if(mHp <= 0)
        {
            mStatus = Status.Dead; // 현상태를 사망으로 한다.
            mCollider.enabled = false; // 허수아비가 사망이면 콜라이더를 비활성화 한다.
            mHp = 0;
            mAnimator.SetTrigger("Die");
            Destroy(gameObject, 1f);

        }
        // --> End sekisuri 20190608 

    }
    // sekisuri 201903 Start <--

    private void SetDamage(int damage)
    {
        mHp = mHp - damage;
        mHealthBar.SendMessage("SetHP", mHp / ScarecrowInfo.Find(mLevel).hp);
    }
}
