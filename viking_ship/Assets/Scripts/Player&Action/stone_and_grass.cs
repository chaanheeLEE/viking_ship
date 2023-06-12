using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stone_and_grass : MonoBehaviour
{
    private WeaponPower weaponPower;
    private Vector3 m_LastPosition;
    public GameObject tree = null;
    public float treeHP;
    private Vector3 angle;
    public PLAYER_INFO user;

    // Start is called before the first frame update
    void Start()
    {
        weaponPower = FindAnyObjectByType<WeaponPower>();
    }

    private void OnCollisionEnter(Collision collision)//충돌발생시
    {
        //태그가 weapon임을 확인
        if (collision.collider.gameObject.CompareTag("Weapon"))
        {
            float speed = (((collision.gameObject.transform.position - m_LastPosition).magnitude) / Time.deltaTime);
            m_LastPosition = collision.gameObject.transform.position;

            if (speed > 5)
            {
                float attackPower = weaponPower.getPower();
                treeHP -= attackPower;
                Debug.Log("cut tree" + treeHP);
                if (treeHP <= 0)
                {
                    Destroy(tree, 10.0f);
                    if(tree.GetComponent<Item_Info>().Item_Num == 2)
                        user.items[1].value += 10;
                    if (tree.GetComponent<Item_Info>().Item_Num == 3)
                        user.items[2].value += 10;
                }
            }
        }
    }
}
