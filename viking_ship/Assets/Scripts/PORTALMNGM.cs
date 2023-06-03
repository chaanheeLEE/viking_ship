using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PORTALMNGM : MonoBehaviour
{
    public Material[] Mat = new Material[2];
    public bool Activation;

    // Start is called before the first frame update
    void Start()
    {
        Activation = false;
        ColorManager();
    }

    // Update is called once per frame
    void Update()
    {
        ColorManager();
    }

    public void ColorManager()
    {
        if (Activation == false)
        {
            gameObject.GetComponent<MeshRenderer>().material = Mat[0];
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().material = Mat[1];
        }
    }

    private void OnTriggerStay(Collider other)

    {
        Activation = true;
    }
}
