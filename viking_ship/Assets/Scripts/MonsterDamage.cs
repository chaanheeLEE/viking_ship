using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDamage : MonoBehaviour
{
    MonsterAI monster;


    private void OnCollisionEnter(Collision collision)//충돌발생시
    {
        //태그가 weapon임을 확인
        if (collision.collider.gameObject.CompareTag("Weapon"))
        {
            monster.GetDamage(10);
        }
    }
}
