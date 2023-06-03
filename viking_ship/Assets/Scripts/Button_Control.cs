using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Control : MonoBehaviour
{
    public PORTALMNGM portal;
    public Button button;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ColorBlock colorBlock = button.colors;
        if (portal.Activation == true)
        {
            button.GetComponent<Button>().interactable = true;
            colorBlock.normalColor = new Color(250, 250, 250, 1);
            button.colors = colorBlock;
        }
        else
        {
            button.GetComponent<Button>().interactable = false;
        }
    }
}
