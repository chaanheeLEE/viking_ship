using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR;


public class Attack : MonoBehaviour
{
    public Stone_In_Inventory stone1;
    public Stone_In_Inventory stone2;
    public Stone_In_Inventory stone3;
    public Material[] material = new Material[2];
    public GameObject cam;
    public GameObject range;
    public AudioSource audio;
    public AudioClip clip1;
    public AudioClip clip2;
    public AudioClip clip3;
    public int Damage;

    private bool Is_CoolTime;

    void Start()
    {
        Is_CoolTime = false;
        transform.GetChild(0).gameObject.SetActive(false);
        range.SetActive(false);
    }

    public void Attack_()
    {
        Damage = 5;
        if (stone1.activation == true)
            Damage = Damage + 5;
        if (stone2.activation == true)
            Damage = Damage + 5;
        if (stone3.activation == true)
            Damage = Damage + 5;
        if (Damage == 20)
            Damage += 5;
        
        if(Damage >= 10 && Is_CoolTime == false && this.gameObject.active == true)
            StartCoroutine("Skill_Shot");
    }

    IEnumerator Skill_Shot()
    {
        StartCoroutine("ResetSkillCoroutine");
        InputDevice xr = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);

        transform.localEulerAngles = new Vector3(cam.transform.localRotation.x + 90, cam.transform.localRotation.y, cam.transform.localRotation.z);

        transform.GetChild(0).gameObject.SetActive(true);
        range.SetActive(true);
        audio.PlayOneShot(clip1);
        audio.PlayOneShot(clip2);
        audio.PlayOneShot(clip3);

        HapticCapabilities capabilities;
        if (xr.TryGetHapticCapabilities(out capabilities))
            if (capabilities.supportsImpulse)
            {
                Debug.Log("진동 1");
                xr.SendHapticImpulse(0, 0.25f, 0.25f);
            }

        xr = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        if (xr.TryGetHapticCapabilities(out capabilities))
            if (capabilities.supportsImpulse)
            {
                Debug.Log("진동 2");
                xr.SendHapticImpulse(0, 0.25f, 0.25f);
            }

        yield return new WaitForSeconds(0.5f);


        transform.eulerAngles = new Vector3(-30, 90, 30);
        transform.GetChild(0).gameObject.SetActive(false);
        range.SetActive(false);

        yield return new WaitForSeconds(0.5f);
    }
    IEnumerator ResetSkillCoroutine() //스킬 쿨타임
    {
        Is_CoolTime = true;
        gameObject.GetComponent<MeshRenderer>().material = material[1];

        yield return new WaitForSeconds(2);

        Is_CoolTime = false;
        gameObject.GetComponent<MeshRenderer>().material = material[0];
    }
}
