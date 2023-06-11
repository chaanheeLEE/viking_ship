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

    public Material[] Mat = new Material[5]; // stone on/off ���׸���

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
        // ����1 Ȱ��ȭ ��/��
        if (stone1_activation == false)
            stone1.GetComponent<MeshRenderer>().material = Mat[0];
        else
            stone1.GetComponent<MeshRenderer>().material = Mat[1];

        // ����2 Ȱ��ȭ ��/��
        if (stone2_activation == false)
            stone2.GetComponent<MeshRenderer>().material = Mat[0];
        else
            stone2.GetComponent<MeshRenderer>().material = Mat[2];

        // ����3 Ȱ��ȭ ��/��
        if (stone3_activation == false)
            stone3.GetComponent<MeshRenderer>().material = Mat[0];
        else
            stone3.GetComponent<MeshRenderer>().material = Mat[3];

        // ����4 Ȱ��ȭ ��/��
        if (stone4_activation == false)
            stone4.GetComponent<MeshRenderer>().material = Mat[0];
        else
            stone4.GetComponent<MeshRenderer>().material = Mat[4];
    }
}
