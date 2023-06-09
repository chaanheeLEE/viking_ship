using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Tool_Action : MonoBehaviour
{
    private Vector3 m_LastPosition;
    private Item_Info item;

    public PLAYER_INFO user;
    public AudioSource audio;
    public AudioClip clip_w;
    public AudioClip clip_s;
    public AudioClip clip_g;
    public Chest_List chest;


    /* ���� ������ ������ ������ ��ġ�ϸ� �κ��丮�� ������ �� + 1 */
    private void OnCollisionEnter(Collision collision)
    {
        InputDevice xr = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        // �����κ� ����
        uint intensity = 6;
        uint duration = 3;   
        // �����κ� ��
        item = this.GetComponent<Item_Info>();
        var component = collision.gameObject.GetComponent<Item_Info>();
        float speed = (((this.gameObject.transform.position - m_LastPosition).magnitude) / Time.deltaTime);
        m_LastPosition = this.gameObject.transform.position;

        //Debug.Log(collision.gameObject.name + ", " + item.Name + ", �浹 ( "+ speed +" )");
        
        if (speed > 5)
        {
            HapticCapabilities capabilities;
            if (xr.TryGetHapticCapabilities(out capabilities))
                if (capabilities.supportsImpulse)
                {
                    Debug.Log("���� 1");
                    xr.SendHapticImpulse(0, 0.25f, 0.25f);
                }

            xr = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
            if (xr.TryGetHapticCapabilities(out capabilities))
                if (capabilities.supportsImpulse)
                {
                    Debug.Log("���� 2");
                    xr.SendHapticImpulse(0, 0.25f, 0.25f);
                }
            switch (component.Item_Num)
            {
                case 0:
                    int i = collision.gameObject.GetComponent<Chest_Info>().Gem_Num;
                    chest.chests[i].SendMessage("Open");
                    break;
                case 1:
                    audio.clip = clip_w;
                    audio.Play();
                    if (component.Name == "����" && item.Name == "����")
                        user.items[0].value++;
                    break;
                case 2:
                    audio.clip = clip_s;
                    audio.Play();
                    if (component.Name == "��" && item.Name == "��ġ")
                        user.items[1].value++;
                    break;
                case 3:
                    audio.clip = clip_g;
                    audio.Play();
                    if (component.Name == "Ǯ" && item.Name == "������")
                        user.items[2].value++;
                    break;
            }
        }
    }
}
