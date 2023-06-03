using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_Text_MNGM : MonoBehaviour
{
    public TMP_Text text;
    public PLAYER_INFO user;
    public int Item_ID;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = user.items[Item_ID].name + " : " + user.items[Item_ID].value;
    }
}
