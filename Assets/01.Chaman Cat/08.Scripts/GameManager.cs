using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;


public enum GameStageMode
{
    NORMAL,
    BOSS,
    ADVENTURE

}

// 던전의 현재 스텝
[InfoBox("게임상태 Enum")]
public enum GameStaus
{
    START,
    IDLE,
    RUN,
    BATTLEIDLE,
    BATTLE,
    CLEAR,
    PAUSE,
    GAMEOVER
}


public class GameManager : MonoBehaviour
{
    //싱글턴에 접근하기 위한 Static 변수 선언
    public static GameManager instance = null;

    public PlayerController mArcher;

    public GameStaus mGameStaus = GameStaus.IDLE;

    GameObject scarecrow;

    public int ScareLevel
    {
        get;set;
    }

    // 경험치를 저장할 변수
    [HideInInspector]
    public int mEXP;

    // 처치한 몬스터 수
    [HideInInspector]
    public int mMonsterKillCnt;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        //instance에 할당된 클래스의 인스턴스가 다를 경우 새로 생성된 클래스를 의미함
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        //다른 씬으로 넘어가더라도 석제하지 않고 유지함
       // DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        InitGame();
    }
    IEnumerator AutoStep()
    {
        while (true)
        {
            if(mGameStaus == GameStaus.IDLE)
            {

            }
        }
    }

    IEnumerator ArcherAttack()
    {
        

        while (mGameStaus == GameStaus.BATTLE)
        {
            // 아처의 공격 애니메이션
            // sekisuri 20190409  mArcher.SetStatus(PlayerControl.Status.Attack, 0);
            mArcher.SetStatus(PlayerController.Status.Attack, 1f); // sekisuri 20190409 기본공격일땐 1초

            // 아처의 공격속도 만큼 대기 후 순환합니다.
            yield return new WaitForSeconds(mArcher.mAttackSpeed);
        }
    }
    [Button]
    public void SetEXP()
    {
        mMonsterKillCnt++;
        mEXP += 5;
        // 경험치를 로컬에 저장
        ES3.Save<int>("2DP_EXP", mEXP);
    }

    [Button]
    public void LoadEXP()
    {
        // 경험치를 로컬에 저장

#if false
        Debug.Log("EXP : " + ES3.Load<int>("2DP_EXP"));
#endif


    }
  
    

    // sekisuri 20190409 Start <--
    [Button]
    public void TouchAttack()
    {
        // 아처의 공격 애니메이션
        // sekisuri 20190409 클릭할땐 공격속도 3초
        mArcher.SetStatus(PlayerController.Status.Attack, 3f);
    }
    // --> End sekisuri 20190409 
    
    private void InitGame()
    {
        ScareLevel = 6;
        //scarecrow = Instantiate(Resources.Load("Scarecrow"),new Vector3(5f,0f,0f),Quaternion.identity) as GameObject;

    }
}
