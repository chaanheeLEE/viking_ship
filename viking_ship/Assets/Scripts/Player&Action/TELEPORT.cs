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

    /* 포탈들을 리스트에 담아두고, n번째 포탈로 플레이어를 이동시킵니다. */
    public void teleport_to_place(int n)
    {
        user.transform.position = portals[n].place.transform.position;
    }
}
