using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Get_Item : MonoBehaviour
{
    public PLAYER_INFO user;
    public string Item_Name;
    public int Item_ID;
    private Vector3 m_LastPosition;

    void Update()
    {
        if (Item_ID != 1 && Item_ID != 2 && Item_ID != 3)
            Get_With_Hand();
    }
    public void Get_With_Hand()
    {
        Debug.Log("입력대기중이지르~");
    }
}
