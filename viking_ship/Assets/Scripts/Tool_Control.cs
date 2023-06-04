using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool_Control : MonoBehaviour
{
    public GameObject Axe;
    public GameObject Hammer;
    public GameObject Knife;
    public GameObject Hand;

    /* ���� ���� �� �Ǽ����� �����մϴ�. */
    void Start()
    {
        Tool_Change(4);
    }

    /* �Լ��� �Ű������� 1�̶�� ����, 2��� ��ġ, 3�̶�� ������, 4��� �Ǽ��Դϴ�. */
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
