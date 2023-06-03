using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TELEPORT : MonoBehaviour
{
    [Serializable]
    public struct Portal
    {
        public GameObject stone;
        public GameObject place;
    }
    public Portal[] portals;

    public GameObject user;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void teleport_to_place(int n)
    {
        user.transform.position = portals[n].place.transform.position;
    }
}
