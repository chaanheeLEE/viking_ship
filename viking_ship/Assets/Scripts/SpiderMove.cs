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

    [SerializeField] float m_fSpeed; //���ǵ�
    [SerializeField] float m_fAngleSpeed; //ȸ�� �ӵ�
    [SerializeField] float m_fRayDist; //���� �浹 ���� ����

    int m_nMoveState = 0; //�ൿ ����
    int m_nRandNum = 1; //�ൿ ���� Ʈ���� ��
    int m_nMoveNum = 0; //�ൿ ī��Ʈ

    float m_fAngle = 0.0f; //x�� ȸ�� ���� ������ ����� ����
    float m_fActionDelay = 0.6f; //�ൿ ���� ������, ������ �ð��� �˾Ƽ� ����
    float m_fMoveDelay = 0.0f; //�̵� ���ѽð�
    float m_fActionAcc = 0.0f; //�ൿ �����ð�
    float m_fMoveAcc = 0.0f; //�̵� �����ð�

    Vector3 m_vDist = new Vector3(0, 0, 0);
    Vector3 m_vPos = new Vector3(0, 0, 0); //������ �ڽ��� ��ǥ��

    //�ٶ󺸰� �ϴ� �ڵ�, ������ ������ �̰� �߿��Ѱ� �ƴϴ� ����
    void Look()
    {
        m_vDist.x = Target.localPosition.x - transform.localPosition.x;
        m_vDist.z = Target.localPosition.z - transform.localPosition.z;

        transform.localRotation = Quaternion.LookRotation(m_vDist).normalized;
    }

    //������Ͱ� ����

    //������ �ð����� �ൿ ī��Ʈ�� �÷��ְų� ���� ���� ������ ���ִ� �Լ�
    //�ൿ ���� Ʈ���� ���� �����ϸ� ���ڿ�������� �������� �����Ѵ�
    //������ �ð����� x�� ȸ�� ������ �����ϴµ� �������� -1 ~ 1���� �����Ѵ�
    // ���� 0�̸� �ƹ� �ϵ� �Ͼ�� ������ 0�� ������ 1�� �ٲ��ش�
    void SetAction()
    {
        if (m_fActionAcc >= m_fActionDelay)
        {
            m_nMoveNum++;
            m_nRandNum = Random.Range(2, 4);

            m_fAngle = (m_fAngle == 0.0f) ? m_fAngle = 1 : Random.Range(-1, 2); //���� �����ڷ� ����ȭ

            m_fActionAcc = 0.0f;
        }
        else
        {
            m_fActionAcc += Time.deltaTime;
        }
    }

    //�ൿ ���°� ����ɶ� ���� ���� �ʱ�ȭ ���ִ� �Լ�
    //�ൿ ī��Ʈ�� ������ ī��Ʈ ��ŭ �����Ǹ� �ൿ ���¸� ����,
    //�̶� �ൿ ī��Ʈ�� 0���� �ʱ�ȭ �����ְ�
    //�ൿ �����ð� ���� �ʱ�ȭ �����ش�
    //���� �̵����� �϶�, �̵� ���ѽð��� �������ش� �̶� �ڿ������� �������� �������ָ� ����
    //�Ű�����(�Ķ����)�� �̿��Ͽ� �ʿ��Ҷ����� ȣ���ų �Լ��� ��Դ´�
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

    //������ Ư�� �ൿ���� ó�����ִ� �Լ�
    void Mob()
    {
        SetAction(); //������ �ð����� ī��Ʈ ����

        Debug.DrawRay(transform.localPosition, transform.forward * m_fRayDist, Color.blue);
        //���濡 ��ֹ��� ������ �������� �߰��Ѵ� �ڽ��� �����̴� transform.forward��

        //switch������ �ൿ �̺�Ʈ���� ���� ó�����ش�
        switch (m_nMoveState)
        {
            case 0: //���
                {
                    SetMoveState(1); //ȸ�� ���·� �ൿ ����
                    m_vPos = Vector3.zero; //��� �����϶� �̵����� �ʴ´�

                    break;
                }
            case 1: //ȸ��
                {
                    SetMoveState(2); //�̵� ���·� �ൿ ����
                    m_vPos = Vector3.zero;
                    transform.Rotate(Vector3.up, m_fAngle * m_fAngleSpeed * Time.deltaTime);
                    //�ൿ ī��Ʈ�� ���� �ɶ� ���� ȸ�� ������ �������� �ٲ��

                    break;
                }
            case 2: //�̵�
                {
                    if (m_fMoveAcc >= m_fMoveDelay) //���ѽð��� �� �Ǿ����� �����·� �ʱ�ȭ
                    {
                        m_fMoveAcc = 0.0f;
                        m_nMoveNum = 0;
                        m_nMoveState = 0;
                    }
                    else
                    {
                        m_fMoveAcc += Time.deltaTime;
                    }

                    RaycastHit hit; //���濡 ��ֹ��� ������ ����
                    m_vPos = transform.forward; //�������� �̵��ؾ� �ϴ� forward�� ����

                    if (Physics.Raycast(transform.localPosition, transform.forward, out hit, m_fRayDist))
                    {
                        if (hit.collider != null) //���濡 ��ֹ��� ���� ���
                        {
                            transform.localRotation = Quaternion.LookRotation(-m_vPos).normalized; //���ٽ�Ų��

                            //���� ��ų���� �̵� ���� ������ �ʱ�ȭ �����ش�
                            m_fMoveAcc = 0.0f;
                            m_nMoveNum = 0;
                            m_fMoveDelay = Random.Range(3.0f, 6.0f);
                        }
                    }
                    break;
                }
        }

        transform.localPosition += m_vPos * m_fSpeed * Time.deltaTime; //�̵� �ڵ�
    }

    void Start()
    {

    }

    void Update()
    {
        //Ÿ�� ���� �з�
        if (m_eType == MonsterType.e_Look)
        {
            Look();
        }
        else if (m_eType == MonsterType.e_Mob)
        {
            Mob(); //�Լ� ȣ��
        }
    }
}
