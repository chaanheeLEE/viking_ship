using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDamage : MonoBehaviour
{
    MonsterAI monster;


    private void OnCollisionEnter(Collision collision)//�浹�߻���
    {
        //�±װ� weapon���� Ȯ��
        if (collision.collider.gameObject.CompareTag("Weapon"))
        {
            monster.GetDamage(10);
        }
    }
}
