using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TELEPORT : MonoBehaviour
{
    [Serializable]
    public struct Portal
    {
        public GameObject stone;
        public GameObject place;
    }
    public Portal[] portals;

    public GameObject user;

    /* ��Ż���� ����Ʈ�� ��Ƶΰ�, n��° ��Ż�� �÷��̾ �̵���ŵ�ϴ�. */
    public void teleport_to_place(int n)
    {
        user.transform.position = portals[n].place.transform.position;
    }
}
