using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Control : MonoBehaviour
{
    public PORTALMNGM portal;
    public Button button;

    void Update()
    {
        /* ��Ż�� Ȱ��ȭ ���¶�� ��ư�� ���� ������� �ϰ� ��ư�� Ȱ��ȭ�մϴ�. */

        ColorBlock colorBlock = button.colors;
        if (portal.Activation == true)
        {
            button.GetComponent<Button>().interactable = true;
            colorBlock.normalColor = new Color(250, 250, 250, 1);
            button.colors = colorBlock;
        }
        else // ��Ȱ��ȭ ���¶�� ���� ���� �����մϴ�.
        {
            button.GetComponent<Button>().interactable = false;
        }
    }
}
