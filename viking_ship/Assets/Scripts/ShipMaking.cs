using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMaking : MonoBehaviour
{
    public GameObject ship;
    public GameObject mast; //��
    public GameObject oar;  //��

    public Material mat0; // ����
    public Material mat1; // �ٴ�
    public Material mat2; // ����
    public Material mat3; // ����
    public Material mat4; // ����

    // Start is called before the first frame update
    private void Start()
    {
        makeShip();
    }
    private void makeShip()
    {
        Material[] mat = ship.GetComponent<MeshRenderer>().materials;
        if (true) {
            mat[0] = mat0;
            mat[1] = mat1;
            if (true) {
                mat[2] = mat2;
                mat[3] = mat3;
                mat[4] = mat4;
                mast.SetActive(true);
                oar.SetActive(true);
            }
        }
        ship.GetComponent<MeshRenderer>().materials = mat;
    }
}
