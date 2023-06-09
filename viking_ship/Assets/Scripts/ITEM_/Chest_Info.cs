using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Chest_Info : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip clip1;
    public AudioClip clip2;
    public GameObject panel;
    public Stone_In_Inventory Gem;
    public int Gem_Num;
    private void Start()
    {
        panel.SetActive(false);
    }
    private void Open()
    {
        if (Gem.activation == false)
        {
            Vector3 Angle = new Vector3(-120, 0, 0);
            transform.GetChild(0).gameObject.transform.Rotate(Angle);
            audio.PlayOneShot(clip1);
            audio.PlayOneShot(clip2);
            Gem.activation = true;
            panel.SetActive(true);
            Destroy(panel, 4);
        }
    }
}
