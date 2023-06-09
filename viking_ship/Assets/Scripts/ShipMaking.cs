using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMaking : MonoBehaviour
{
    public GameObject ship;
    public GameObject mast; //µÀ
    public GameObject oar;  //³ë

    public Material bone; // »À´ë
    public Material floor; // ¹Ù´Ú
    public Material interior; // ³»ºÎ
    public Material rope; // ÁÙ
    public Material deco; // ¹æÆÐ

    // Start is called before the first frame update
    private void Start()
    {
        makeShip();
    }
    private void makeShip()
    {
        Material[] mat = ship.GetComponent<MeshRenderer>().materials;
        if (true) {
            mat[0] = bone;
            mat[1] = floor;
            if (true) {
                mat[2] = interior;
                mat[3] = rope;
                mat[4] = deco;
                mast.SetActive(true);
                oar.SetActive(true);
            }
        }
        ship.GetComponent<MeshRenderer>().materials = mat;
    }
}
