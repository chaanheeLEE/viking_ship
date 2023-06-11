using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterAI : MonoBehaviour
{
    Transform target;
    NavMeshAgent nmAgent;
    Animator anim;

    public float HP = 1000.0f;
    public float lostDistance;
    public ParticleSystem particle;
    enum State
    {
        IDLE,
        CHASE,
        ATTACK,
        KILLED
    }

    State state;
    bool cancelWait;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        nmAgent = GetComponent<NavMeshAgent>();

        state = State.IDLE;
        StartCoroutine(StateMachine());
    }

    IEnumerator StateMachine()
    {
        while (state != State.KILLED)
        {
            yield return StartCoroutine(state.ToString());
        }

        yield return StartCoroutine(State.KILLED.ToString());
    }

    IEnumerator CancelableWait(float t)
    {
        cancelWait = false;
        while (t > 0 && cancelWait == false)
        {
            t -= Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator IDLE()
    {
        // 현재 animator 상태정보 얻기
        var curAnimStateInfo = anim.GetCurrentAnimatorStateInfo(0);

        // 애니메이션 이름이 Idle 이 아니면 Play
        if (curAnimStateInfo.IsName("Idle") == false)
            anim.Play("Idle", 0, 0);

        // 몬스터가 Idle 상태일 때 두리번 거리게 하는 코드
        // 50% 확률로 좌/우로 돌아 보기
        int dir = Random.Range(0f, 1f) > 0.5f ? 1 : -1;

        // 회전 속도 설정
        float lookSpeed = Random.Range(25f, 40f);

        // Idle재생 시간 동안 돌아보기
        for (float i = 0; i < curAnimStateInfo.length; i += Time.deltaTime)
        {
            if (state == State.KILLED) break;
            transform.localEulerAngles = new Vector3(0f, transform.localEulerAngles.y + (dir) * Time.deltaTime * lookSpeed, 0f);
            yield return null;
        }
    }

    IEnumerator CHASE()
    {
        var curAnimStateInfo = anim.GetCurrentAnimatorStateInfo(0);

        if (curAnimStateInfo.IsName("Walk") == false)
        {
            anim.Play("Walk", -1, 0);
            // SetDestination 을 위해 한 frame을 넘기기위한 코드
            yield return null;
        }

        // 목표까지의 남은 거리가 멈추는 지점보다 작거나 같으면
        if (nmAgent.remainingDistance <= nmAgent.stoppingDistance)
        {
            // StateMachine 을 공격으로 변경
            nmAgent.isStopped = true;
            ChangeState(State.ATTACK);
        }
        // 목표와의 거리가 멀어진 경우
        else if (nmAgent.remainingDistance > lostDistance)
        {
            target = null;
            nmAgent.SetDestination(transform.position);
            yield return null;
            // StateMachine 을 대기로 변경
            ChangeState(State.IDLE);
        }
        else
        {
            // Walk 애니메이션의 한 사이클 동안 대기
            //yield return new WaitForSeconds(0.5f);
            yield return StartCoroutine(CancelableWait(0.5f));
        }
    }
    
    IEnumerator ATTACK()
    {
        var curAnimStateInfo = anim.GetCurrentAnimatorStateInfo(0);

        // 공격 애니메이션은 공격 후 Idle0로 이동하기 때문에 
        // 코드가 이 지점에 오면 무조건 Attack1 을 Play

        yield return new WaitUntil(() => anim.GetCurrentAnimatorStateInfo(0).IsName("Damage") == false);

        anim.Play("Attack1", -1, 0);
        particle.Play();
        attackPlyaer();

        // 거리가 멀어지면
        if (nmAgent.remainingDistance > nmAgent.stoppingDistance)
        {
            // StateMachine을 추적으로 변경
            ChangeState(State.CHASE);
        }
        else
            // 공격 animation 길이 만큼 대기
            // 이 대기 시간을 이용해 공격 간격을 조절할 수 있음.         
            yield return StartCoroutine(CancelableWait(curAnimStateInfo.length));
    }
    

    IEnumerator KILLED()
    {
        anim.Play("Death", -1, 0);
        Destroy(this, 10.0f);
        yield return null;
    }

    void ChangeState(State newState)
    {
        state = newState;
    }

    private void OnTriggerStay(Collider other)
    {
        if (state == State.KILLED) return;
        if (other.tag == "Player") 
        {
            // Sphere Collider 가 Player 를 감지하면      
            target = other.transform;
            // NavMeshAgent의 목표를 Player 로 설정
            nmAgent.SetDestination(target.position);
            ChangeState(State.CHASE);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;

        if (state == State.ATTACK)
            transform.LookAt(target);

        nmAgent.SetDestination(target.position);
    }

    public void GetDamage(int dmg)
    {
        HP -= dmg;

        if (HP <= 0)
        {
            target = null;
            cancelWait = true;
            ChangeState(State.KILLED);
        }
        else 
        {
            anim.Play("Damage", -1, 0);
            Debug.Log("spider" + HP);
        }
            
    }

    public void attackPlyaer()
    {
        if (target == null) return;
        target.GetComponent<PLAYER_INFO>().GetDamage(10);
    }
}
