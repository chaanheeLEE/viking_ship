using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/* �÷��̾�� ���õ� ������ ����ֽ��ϴ�. */
public class PLAYER_INFO : MonoBehaviour
{
    MonsterAI monster;
    [Serializable]
    public struct Item
    {
        public int id;
        public string name;
        public int value;
    }

    public Item[] items;
    public int health = 100;
    public void GetDamage(int dmg)
    {
        health -= dmg;
        Debug.Log("player" + health);
    }

}
