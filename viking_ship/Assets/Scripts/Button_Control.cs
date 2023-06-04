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
        /* 포탈이 활성화 상태라면 버튼의 색을 흰색으로 하고 버튼을 활성화합니다. */

        ColorBlock colorBlock = button.colors;
        if (portal.Activation == true)
        {
            button.GetComponent<Button>().interactable = true;
            colorBlock.normalColor = new Color(250, 250, 250, 1);
            button.colors = colorBlock;
        }
        else // 비활성화 상태라면 원래 색을 유지합니다.
        {
            button.GetComponent<Button>().interactable = false;
        }
    }
}
