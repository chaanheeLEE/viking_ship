using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMaking : MonoBehaviour
{
    public GameObject ship;
    public GameObject mast; //��
    public GameObject oar;  //��

    public Material bone; // ����
    public Material floor; // �ٴ�
    public Material interior; // ����
    public Material rope; // ��
    public Material deco; // ����

    // Start is called before the first frame update
    private void Start()
    {
        if (true) //����Ʈ ��������
        {
            makeShip();
        }
        
    }
    private void makeShip()
    {
        Material[] mat = ship.GetComponent<MeshRenderer>().materials;
        if (true) { //����Ʈ ����
            mat[0] = bone;
            mat[1] = floor;}
            if (true) {
                mat[2] = interior;
                mat[3] = rope;
                mat[4] = deco;
                mast.SetActive(true);
                oar.SetActive(true);
            }
     
            ship.GetComponent<MeshRenderer>().materials = mat;
    }
}
