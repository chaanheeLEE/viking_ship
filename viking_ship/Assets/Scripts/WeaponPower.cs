using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPower : MonoBehaviour
{
    public GameObject weapon;
    private float power;
    // 휘두름 동작 감지
    private void Update()
    {
        
    }
    public float getPower() 
    {
        power = weapon.GetComponent<Rigidbody>().mass * weapon.GetComponent<Rigidbody>().velocity.magnitude;
        return power;
    }
}
