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
        // ���� animator �������� ���
        var curAnimStateInfo = anim.GetCurrentAnimatorStateInfo(0);

        // �ִϸ��̼� �̸��� Idle �� �ƴϸ� Play
        if (curAnimStateInfo.IsName("Idle") == false)
            anim.Play("Idle", 0, 0);

        // ���Ͱ� Idle ������ �� �θ��� �Ÿ��� �ϴ� �ڵ�
        // 50% Ȯ���� ��/��� ���� ����
        int dir = Random.Range(0f, 1f) > 0.5f ? 1 : -1;

        // ȸ�� �ӵ� ����
        float lookSpeed = Random.Range(25f, 40f);

        // Idle��� �ð� ���� ���ƺ���
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
            // SetDestination �� ���� �� frame�� �ѱ������ �ڵ�
            yield return null;
        }

        // ��ǥ������ ���� �Ÿ��� ���ߴ� �������� �۰ų� ������
        if (nmAgent.remainingDistance <= nmAgent.stoppingDistance)
        {
            // StateMachine �� �������� ����
            nmAgent.isStopped = true;
            ChangeState(State.ATTACK);
        }
        // ��ǥ���� �Ÿ��� �־��� ���
        else if (nmAgent.remainingDistance > lostDistance)
        {
            target = null;
            nmAgent.SetDestination(transform.position);
            yield return null;
            // StateMachine �� ���� ����
            ChangeState(State.IDLE);
        }
        else
        {
            // Walk �ִϸ��̼��� �� ����Ŭ ���� ���
            //yield return new WaitForSeconds(0.5f);
            yield return StartCoroutine(CancelableWait(0.5f));
        }
    }
    
    IEnumerator ATTACK()
    {
        var curAnimStateInfo = anim.GetCurrentAnimatorStateInfo(0);

        // ���� �ִϸ��̼��� ���� �� Idle0�� �̵��ϱ� ������ 
        // �ڵ尡 �� ������ ���� ������ Attack1 �� Play

        yield return new WaitUntil(() => anim.GetCurrentAnimatorStateInfo(0).IsName("Damage") == false);

        anim.Play("Attack1", -1, 0);
        particle.Play();
        attackPlyaer();

        // �Ÿ��� �־�����
        if (nmAgent.remainingDistance > nmAgent.stoppingDistance)
        {
            // StateMachine�� �������� ����
            ChangeState(State.CHASE);
        }
        else
            // ���� animation ���� ��ŭ ���
            // �� ��� �ð��� �̿��� ���� ������ ������ �� ����.         
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
            // Sphere Collider �� Player �� �����ϸ�      
            target = other.transform;
            // NavMeshAgent�� ��ǥ�� Player �� ����
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
