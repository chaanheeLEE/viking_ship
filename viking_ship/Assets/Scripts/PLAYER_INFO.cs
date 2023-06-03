using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
