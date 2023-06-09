using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool_Control : MonoBehaviour
{
    public GameObject Axe;
    public GameObject Hammer;
    public GameObject Knife;
    public GameObject Hand;

    /* 게임 시작 시 맨손으로 시작합니다. */
    void Start()
    {
        Tool_Change(4);
    }

    /* 함수의 매개변수가 1이라면 도끼, 2라면 망치, 3이라면 나이프, 4라면 맨손입니다. */
    public void Tool_Change(int Tool_Num)
    {
        
        switch (Tool_Num)
        {
            case 1:
                Axe.SetActive(true);
                Hammer.SetActive(false);
                Knife.SetActive(false);
                Hand.SetActive(false);
                break;
            case 2:
                Axe.SetActive(false);
                Hammer.SetActive(true);
                Knife.SetActive(false);
                Hand.SetActive(false);
                break;
            case 3:
                Axe.SetActive(false);
                Hammer.SetActive(false);
                Knife.SetActive(true);
                Hand.SetActive(false);
                break;
            case 4:
                Axe.SetActive(false);
                Hammer.SetActive(false);
                Knife.SetActive(false);
                Hand.SetActive(true);
                break;
        }
    }
}
