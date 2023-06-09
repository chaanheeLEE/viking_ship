using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMaking : MonoBehaviour
{
    public GameObject ship;
    public GameObject mast; //µÀ
    public GameObject oar;  //³ë

    public Material mat0; // »À´ë
    public Material mat1; // ¹Ù´Ú
    public Material mat2; // ³»ºÎ
    public Material mat3; // µÀ´ë
    public Material mat4; // ¹æÆÐ

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
