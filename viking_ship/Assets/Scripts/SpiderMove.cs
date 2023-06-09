using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum MonsterType
{
    e_Look,
    e_Mob
};
public class SpiderMove : MonoBehaviour
{
    public MonsterType m_eType;
    [SerializeField] Transform Target;

    [SerializeField] float m_fSpeed; //스피드
    [SerializeField] float m_fAngleSpeed; //회전 속도
    [SerializeField] float m_fRayDist; //전방 충돌 감지 범위

    int m_nMoveState = 0; //행동 상태
    int m_nRandNum = 1; //행동 변경 트리거 값
    int m_nMoveNum = 0; //행동 카운트

    float m_fAngle = 0.0f; //x축 회전 방향 지정에 써먹을 변수
    float m_fActionDelay = 0.6f; //행동 변경 딜레이, 딜레이 시간은 알아서 지정
    float m_fMoveDelay = 0.0f; //이동 제한시간
    float m_fActionAcc = 0.0f; //행동 누적시간
    float m_fMoveAcc = 0.0f; //이동 누적시간

    Vector3 m_vDist = new Vector3(0, 0, 0);
    Vector3 m_vPos = new Vector3(0, 0, 0); //저장할 자신의 좌표값

    //바라보게 하는 코드, 하지만 지금은 이게 중요한게 아니니 무시
    void Look()
    {
        m_vDist.x = Target.localPosition.x - transform.localPosition.x;
        m_vDist.z = Target.localPosition.z - transform.localPosition.z;

        transform.localRotation = Quaternion.LookRotation(m_vDist).normalized;
    }

    //여기부터가 시작

    //지정한 시간동안 행동 카운트를 늘려주거나 랜덤 값을 재지정 해주는 함수
    //행동 변경 트리거 값은 일정하면 부자연스러우니 랜덤으로 조정한다
    //지정한 시간마다 x축 회전 방향을 지정하는데 랜덤으로 -1 ~ 1까지 지정한다
    // 만약 0이면 아무 일도 일어나지 않으니 0이 나오면 1로 바꿔준다
    void SetAction()
    {
        if (m_fActionAcc >= m_fActionDelay)
        {
            m_nMoveNum++;
            m_nRandNum = Random.Range(2, 4);

            m_fAngle = (m_fAngle == 0.0f) ? m_fAngle = 1 : Random.Range(-1, 2); //삼항 연산자로 간소화

            m_fActionAcc = 0.0f;
        }
        else
        {
            m_fActionAcc += Time.deltaTime;
        }
    }

    //행동 상태가 변경될때 마다 값을 초기화 해주는 함수
    //행동 카운트가 지정한 카운트 만큼 누적되면 행동 상태를 변경,
    //이때 행동 카운트를 0으로 초기화 시켜주고
    //행동 누적시간 또한 초기화 시켜준다
    //만약 이동상태 일때, 이동 제한시간을 지정해준다 이때 자연스럽게 랜덤으로 지정해주면 좋다
    //매개변수(파라미터)를 이용하여 필요할때마다 호출시킬 함수로 써먹는다
    void SetMoveState(int nState)
    {
        if (m_nMoveNum >= m_nRandNum)
        {
            m_fActionAcc = 0.0f;
            m_nMoveNum = 0;
            m_fMoveDelay = Random.Range(3.0f, 6.0f);
            m_nMoveState = nState;
        }
    }

    //몬스터의 특정 행동들을 처리해주는 함수
    void Mob()
    {
        SetAction(); //지정된 시간마다 카운트 누적

        Debug.DrawRay(transform.localPosition, transform.forward * m_fRayDist, Color.blue);
        //전방에 장애물을 감지할 레이저도 추가한다 자신의 정면이니 transform.forward로

        //switch문으로 행동 이벤트들을 각각 처리해준다
        switch (m_nMoveState)
        {
            case 0: //대기
                {
                    SetMoveState(1); //회전 상태로 행동 변경
                    m_vPos = Vector3.zero; //대기 상태일땐 이동하지 않는다

                    break;
                }
            case 1: //회전
                {
                    SetMoveState(2); //이동 상태로 행동 변경
                    m_vPos = Vector3.zero;
                    transform.Rotate(Vector3.up, m_fAngle * m_fAngleSpeed * Time.deltaTime);
                    //행동 카운트가 누적 될때 마다 회전 방향이 랜덤으로 바뀐다

                    break;
                }
            case 2: //이동
                {
                    if (m_fMoveAcc >= m_fMoveDelay) //제한시간이 다 되었을때 대기상태로 초기화
                    {
                        m_fMoveAcc = 0.0f;
                        m_nMoveNum = 0;
                        m_nMoveState = 0;
                    }
                    else
                    {
                        m_fMoveAcc += Time.deltaTime;
                    }

                    RaycastHit hit; //전방에 장애물을 감지할 변수
                    m_vPos = transform.forward; //전방으로 이동해야 하니 forward값 저장

                    if (Physics.Raycast(transform.localPosition, transform.forward, out hit, m_fRayDist))
                    {
                        if (hit.collider != null) //전방에 장애물이 있을 경우
                        {
                            transform.localRotation = Quaternion.LookRotation(-m_vPos).normalized; //빠꾸시킨다

                            //빠꾸 시킬때는 이동 한정 변수만 초기화 시켜준다
                            m_fMoveAcc = 0.0f;
                            m_nMoveNum = 0;
                            m_fMoveDelay = Random.Range(3.0f, 6.0f);
                        }
                    }
                    break;
                }
        }

        transform.localPosition += m_vPos * m_fSpeed * Time.deltaTime; //이동 코드
    }

    void Start()
    {

    }

    void Update()
    {
        //타입 별로 분류
        if (m_eType == MonsterType.e_Look)
        {
            Look();
        }
        else if (m_eType == MonsterType.e_Mob)
        {
            Mob(); //함수 호출
        }
    }
}
