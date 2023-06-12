using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testspawer : MonoBehaviour
{

    public GameObject viking;
    public Transform positon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Instantiate(viking, positon.position, positon.rotation);
        
    }
}
