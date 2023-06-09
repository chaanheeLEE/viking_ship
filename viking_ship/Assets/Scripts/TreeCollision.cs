using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCollision : MonoBehaviour
{
    private WeaponPower weaponPower;
    public GameObject tree;
    public float treeHP;
    private Vector3 angle;
    public PLAYER_INFO user;

    // Start is called before the first frame update
    void Start()
    {
        weaponPower = FindAnyObjectByType<WeaponPower>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)//충돌발생시
    {
        //태그가 weapon임을 확인
        if (collision.collider.gameObject.CompareTag("Weapon")) 
        {
            float attackPower = weaponPower.getPower();
            treeHP -= attackPower;
            Debug.Log("cut tree"+treeHP);
            if (treeHP <= 0) 
            {
                tree.GetComponent<Rigidbody>().constraints 
                    = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationY; //리지드바디 제약(포지션, 로테이션)
                
                ContactPoint contactPoint = collision.GetContact(0); //충돌 지점 구하고
                angle = -contactPoint.normal;    //노말벡터
                tree.transform.rotation = Quaternion.Euler(angle*25); //공격받은 각도로 넘어지도록 각도 조정
                
                Destroy(tree, 15.0f);
                user.items[0].value +=10;
            }
        }
    }
}
