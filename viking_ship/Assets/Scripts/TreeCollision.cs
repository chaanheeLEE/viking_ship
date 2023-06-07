using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCollision : MonoBehaviour
{
    private WeaponPower weaponPower;
    public GameObject tree;
    public float treeHP;
    private Vector3 angle;
    // Start is called before the first frame update
    void Start()
    {
        weaponPower = FindAnyObjectByType<WeaponPower>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        float attackPower = weaponPower.getPower();
        if (collision.collider.gameObject.CompareTag("Weapon")) 
        {
            treeHP -= attackPower;
            Debug.Log("cut tree"+treeHP);
            if (treeHP <= 0) 
            {
                ContactPoint contactPoint = collision.GetContact(0);
                angle = contactPoint.normal;    
                tree.transform.rotation = Quaternion.Euler(angle*30);
                Destroy(tree, 10.0f);
            }
        }
    }
}
