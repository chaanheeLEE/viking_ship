using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool_Action : MonoBehaviour
{
    private Vector3 m_LastPosition;
    private Item_Info item;
    public PLAYER_INFO user;

    /* ���� ������ ������ ������ ��ġ�ϸ� �κ��丮�� ������ �� + 1 */
    private void OnCollisionEnter(Collision collision)
    {
        item = this.GetComponent<Item_Info>();
        var component = collision.gameObject.GetComponent<Item_Info>();
        float speed = (((this.gameObject.transform.position - m_LastPosition).magnitude) / Time.deltaTime);
        m_LastPosition = this.gameObject.transform.position;

        Debug.Log(component.Name + "��(��) " + this.name + ", �浹 ����!\n�ӵ� : " + speed);

        if (speed > 10)
        {
            switch (component.Item_Num)
            {
                case 1:
                    if (component.Name == "����" && item.Name == "����")
                        user.items[0].value++;
                    break;
                case 2:
                    if (component.Name == "��" && item.Name == "��ġ")
                        user.items[1].value++;
                    break;
                case 3:
                    if (component.Name == "Ǯ" && item.Name == "������")
                        user.items[2].value++;
                    break;
            }
        }
    }
}
