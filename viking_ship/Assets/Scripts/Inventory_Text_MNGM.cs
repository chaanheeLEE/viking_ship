using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_Text_MNGM : MonoBehaviour
{
    private TMP_Text text;
    public PLAYER_INFO user;
    public int Item_ID;

    /* 아이템 ID에 맞는 아이템명과 수량을 텍스트 오브젝트에 적습니다. */
    void Update()
    {
        text = this.GetComponent<TMP_Text>();
        text.text = user.items[Item_ID].name + " : " + user.items[Item_ID].value;
    }
}
