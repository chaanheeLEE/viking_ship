using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPower : MonoBehaviour
{
    public GameObject weapon;
    private float power;
    private void Update()
    {
        
    }
    public float getPower() 
    {   
        //f=ma·Î Èû °è»ê
        power = weapon.GetComponent<Rigidbody>().mass * weapon.GetComponent<Rigidbody>().velocity.magnitude;
        return power;
    }
}
