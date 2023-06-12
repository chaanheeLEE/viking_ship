using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActive : MonoBehaviour
{
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        if (true) //퀘스트 시작조건
        {
            enemy.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
