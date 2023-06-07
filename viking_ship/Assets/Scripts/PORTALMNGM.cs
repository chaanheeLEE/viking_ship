using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class PORTALMNGM : MonoBehaviour
{
    public Material[] Mat = new Material[2];
    public bool Activation;

    /* ���� �� ��Ż�� ��Ȱ��ȭ�մϴ�. */
    void Start()
    {
        Activation = false;
        ColorManager();
    }

    void Update()
    {
        ColorManager();
    }

    /* ��Ż�� Ȱ��ȭ ����(Activation ����)�� ���� ��Ż�� ���� �ٸ��� ǥ���մϴ�. */
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

    /* �ٸ� ��ü(�÷��̾�, ����ü ��)�� �����ϸ� ��Ż Ȱ��ȭ */
    private void OnTriggerStay(Collider other)
    {
        Activation = true;
    }
}
