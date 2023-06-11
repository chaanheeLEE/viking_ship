using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneManager : MonoBehaviour
{

    public GameObject stone1;
    public GameObject stone2;
    public GameObject stone3;
    public GameObject stone4;

    public bool stone1_activation;
    public bool stone2_activation;
    public bool stone3_activation;
    public bool stone4_activation;

    public Material[] Mat = new Material[5]; // stone on/off 마테리얼

    // Start is called before the first frame update
    void Start()
    {
        stone1_activation = false;
        stone2_activation = false;
        stone3_activation = false;
        stone4_activation = false;

    }

    // Update is called once per frame
    void Update()
    {   
        // 보석1 활성화 전/후
        if (stone1_activation == false)
            stone1.GetComponent<MeshRenderer>().material = Mat[0];
        else
            stone1.GetComponent<MeshRenderer>().material = Mat[1];

        // 보석2 활성화 전/후
        if (stone2_activation == false)
            stone2.GetComponent<MeshRenderer>().material = Mat[0];
        else
            stone2.GetComponent<MeshRenderer>().material = Mat[2];

        // 보석3 활성화 전/후
        if (stone3_activation == false)
            stone3.GetComponent<MeshRenderer>().material = Mat[0];
        else
            stone3.GetComponent<MeshRenderer>().material = Mat[3];

        // 보석4 활성화 전/후
        if (stone4_activation == false)
            stone4.GetComponent<MeshRenderer>().material = Mat[0];
        else
            stone4.GetComponent<MeshRenderer>().material = Mat[4];
    }
}
