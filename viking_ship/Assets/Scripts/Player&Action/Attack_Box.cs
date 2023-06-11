using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Box : MonoBehaviour
{
    private int damage;
    
    private void OnCollisionStay(Collision collision)
    {
        damage = transform.parent.GetComponent<Attack>().Damage;

        if(collision.gameObject.tag == "enemy"){
            collision.gameObject.SendMessage("Attacked", damage);
        }

    }
}
