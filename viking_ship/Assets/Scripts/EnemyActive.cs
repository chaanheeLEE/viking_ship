using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActive : MonoBehaviour
{
    public GameObject enemy;
    public GameObject chest;
    // Start is called before the first frame update
    void Start()
    {
        chest.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.transform.childCount == 1)
        {
            chest.SetActive(true);
        }
    }
}
