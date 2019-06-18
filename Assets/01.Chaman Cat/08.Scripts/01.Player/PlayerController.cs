using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameManager mGameManager;
    private Animator mAnimator;

    // 화살 프리팹을 참조합니다.
    public Object mArrowPrefab;

  
    // 화살이 발사되는 지점.
    [HideInInspector]
    private Transform mAttackSpot;

    // 아처의 체력, 공격력, 공격속도에 사용할 변수
    public int mOrinHp;
    [HideInInspector]
    public int mHp;

    public int mOrinAttack;
    [HideInInspector]
    public int mAttack;

    public float mAttackSpeed;

    public bool IsCritical = false;

    
    // 아처의 상태(대기, 달림, 공격, 사망)
    public enum Status
    {
        Idle,
        Run,
        Attack,
        Dead,
        Reborn
    }
    // public으로 선언되었지만 인스펙터 뷰(Inspector View)에 노출되지 않기를 원할 경우 HideInInspector를 선언
    [HideInInspector]
    public Status mStatus = Status.Idle; // 아처의 Default 상태를 Idle로 설정

    private void Start()
    {
        mAnimator = gameObject.GetComponent<Animator>();
        // 자식(child) 게임 오브젝트 중 spot 이라는 이름의 오브젝트를 찾아 transform 컴포넌트의 레퍼런스를 반환합니다.
        mAttackSpot = transform.Find("spot");
        
    }
    // 아처의 상태를 컨트롤 합니다.
    public void SetStatus(Status status, float param)
    {
        // 애니메이터에서 만든 상태간 전이(Transition)들을 상황에 맞게 호출합니다.
        switch (status)
        {
            case Status.Idle:
               
                break;
            case Status.Run:
               
                break;
            case Status.Attack:
                // sekisuri 2019-6-15 크리티컬 퍼센트를 결정한다.
                int critPer = Random.Range(0, 10);
                if (critPer > 4) // 우선은 크리확률 50퍼센트
                {
                    IsCritical = true;
                }
                else
                {
                    IsCritical = false;
                }
                    //  mHpControl.gameObject.SetActive(true);// sekisuri 20190330 체력바 추가
#if false
                    Debug.Log("Attack");
#endif
                mAnimator.SetFloat("AttSpeed", param); // sekisuri 20190409 애니메이션 공격속도추가
                mAnimator.SetTrigger("Shoot");
                break;
            case Status.Dead:
                break;
            case Status.Reborn:
                break;
        }
    }

    private void ShootArrow()
    {
        // 화살 프리팹을 인스턴스화 합니다.
        GameObject arrow = Instantiate(mArrowPrefab, mAttackSpot.position, Quaternion.identity) as GameObject;
        //// 화살 게임오브젝트의 컴포넌트에서 Shoot 함수를 호출합니다.
        arrow.SendMessage("Shoot");
    }

    public int GetRandomDamage()
    {// 플레이어 데미지 파워를 결정한다.
        return mAttack + Random.Range(0, 20);
    }
}
