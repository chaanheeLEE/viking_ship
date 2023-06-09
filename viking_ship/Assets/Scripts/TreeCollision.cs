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
    private void OnCollisionEnter(Collision collision)//�浹�߻���
    {
        //�±װ� weapon���� Ȯ��
        if (collision.collider.gameObject.CompareTag("Weapon")) 
        {
            float attackPower = weaponPower.getPower();
            treeHP -= attackPower;
            Debug.Log("cut tree"+treeHP);
            if (treeHP <= 0) 
            {
                tree.GetComponent<Rigidbody>().constraints 
                    = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationY; //������ٵ� ����(������, �����̼�)
                
                ContactPoint contactPoint = collision.GetContact(0); //�浹 ���� ���ϰ�
                angle = -contactPoint.normal;    //�븻����
                tree.transform.rotation = Quaternion.Euler(angle*25); //���ݹ��� ������ �Ѿ������� ���� ����
                
                Destroy(tree, 15.0f);
                user.items[0].value +=10;
            }
        }
    }
}
