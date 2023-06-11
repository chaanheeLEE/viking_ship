using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Stone_In_Inventory : MonoBehaviour
{
    public bool activation;
    public Material[] Mat = new Material[2]; // stone on/off 마테리얼

    void Start()
    {
        activation = false;
    }

    // Update is called once per frame
    void Update()
    {
        color_update();
    }
    private void color_update()
    {
        if (activation == false)
            gameObject.GetComponent<MeshRenderer>().material = Mat[0];
        else
            gameObject.GetComponent<MeshRenderer>().material = Mat[1];
    }

}
