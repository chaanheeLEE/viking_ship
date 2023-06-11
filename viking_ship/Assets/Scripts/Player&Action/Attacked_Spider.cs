using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacked_Spider : MonoBehaviour
{
    public Material[] material = new Material[2];
    private bool delay = false;
    public void Attacked(int damage)
    {
        if (delay == false)
        {
            StartCoroutine("Delay");
            StartCoroutine("Mat");
            Debug.Log("공격당함! 데미지 : " + damage);
        }
    }

    IEnumerator Mat()
    {
            transform.GetChild(7).gameObject.GetComponent<SkinnedMeshRenderer>().material = material[1];
            yield return new WaitForSeconds(0.3f);
            transform.GetChild(7).gameObject.GetComponent<SkinnedMeshRenderer>().material = material[0];
    }

    IEnumerator Delay()
    {
        delay = true;
        yield return new WaitForSeconds(1);
        delay = false;
    }
}
