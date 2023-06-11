using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float HP = 100;
    MonsterAI target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetDamage(float dmg)
    {
        HP -= dmg;
    }
    void attack() {
        if (target == null || target.HP <= 0) return;
        target.GetDamage(10);
    }
}
