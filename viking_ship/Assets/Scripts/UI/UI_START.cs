using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_START : MonoBehaviour
{
    public GameObject main;
    public GameObject inven;
    public GameObject tele;
    public GameObject quest;

    void Start()
    {
        main.SetActive(true);
        inven.SetActive(false);
        tele.SetActive(false);
        quest.SetActive(false);
    }
}
