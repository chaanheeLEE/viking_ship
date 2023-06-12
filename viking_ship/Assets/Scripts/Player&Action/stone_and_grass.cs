using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stone_and_grass : MonoBehaviour
{
    private WeaponPower weaponPower;
    private Vector3 m_LastPosition;
    private GameObject tree;
    public float treeHP;
    private Vector3 angle;
    public PLAYER_INFO user;

    private void Update()
    {
        if (treeHP < 0)
        {
            tree = this.gameObject;
            Destroy(tree, 0f);
            if (tree.GetComponent<Item_Info>().Item_Num == 2)
                user.items[1].value += 10;
            if (tree.GetComponent<Item_Info>().Item_Num == 3)
                user.items[2].value += 10;
        }
    }
}
