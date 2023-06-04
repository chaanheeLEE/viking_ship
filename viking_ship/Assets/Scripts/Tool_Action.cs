using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool_Action : MonoBehaviour
{
    private Vector3 m_LastPosition;
    private Item_Info item;
    public PLAYER_INFO user;

    /* 도구 종류와 아이템 정보가 일치하면 인벤토리의 아이템 수 + 1 */
    private void OnCollisionEnter(Collision collision)
    {
        item = this.GetComponent<Item_Info>();
        var component = collision.gameObject.GetComponent<Item_Info>();
        float speed = (((this.gameObject.transform.position - m_LastPosition).magnitude) / Time.deltaTime);
        m_LastPosition = this.gameObject.transform.position;

        Debug.Log(component.Name + "와(과) " + this.name + ", 충돌 시작!\n속도 : " + speed);

        if (speed > 10)
        {
            switch (component.Item_Num)
            {
                case 1:
                    if (component.Name == "나무" && item.Name == "도끼")
                        user.items[0].value++;
                    break;
                case 2:
                    if (component.Name == "돌" && item.Name == "망치")
                        user.items[1].value++;
                    break;
                case 3:
                    if (component.Name == "풀" && item.Name == "나이프")
                        user.items[2].value++;
                    break;
            }
        }
    }
}
