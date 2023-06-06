using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class PORTALMNGM : MonoBehaviour
{
    public Material[] Mat = new Material[2];
    public bool Activation;

    /* 시작 시 포탈을 비활성화합니다. */
    void Start()
    {
        Activation = false;
        ColorManager();
    }

    void Update()
    {
        ColorManager();
    }

    /* 포탈의 활성화 상태(Activation 변수)에 따라 포탈의 색을 다르게 표시합니다. */
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

    /* 다른 물체(플레이어, 투사체 등)과 접촉하면 포탈 활성화 */
    private void OnTriggerStay(Collider other)
    {
        Activation = true;
    }
}
