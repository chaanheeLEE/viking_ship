using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/* 플레이어와 관련된 정보가 담겨있습니다. */
public class PLAYER_INFO : MonoBehaviour
{
    [Serializable]
    public struct Item
    {
        public int id;
        public string name;
        public int value;
    }

    public Item[] items;
    public int health;
   
}
