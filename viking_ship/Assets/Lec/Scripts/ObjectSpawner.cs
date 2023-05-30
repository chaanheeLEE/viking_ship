using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectSpawner : MonoBehaviour
{
    private PrimitiveType objectType;
    private float objectSize;

    public Slider sizeSlider;
    public TMPro.TMP_Dropdown typeDropdown;

    public void Start()
    {
        ChangeObjectSize();
        ChangeObjectType();
    }

    public void SpawnObject()
    {
        var obj = GameObject.CreatePrimitive(objectType);
        obj.AddComponent<Rigidbody>();
        obj.transform.localScale = Vector3.one * objectSize;
        obj.transform.position = this.transform.position;
        obj.GetComponent<Renderer>().material.color = Random.ColorHSV();
    }

    public void ChangeObjectSize()
    {
        objectSize = sizeSlider.value;
    }

    public void ChangeObjectType()
    {
        if(typeDropdown.value == 0)
        {
            objectType = PrimitiveType.Sphere;
        }
        else if (typeDropdown.value == 1)
        {
            objectType = PrimitiveType.Cube;
        }
        else if (typeDropdown.value == 2)
        {
            objectType = PrimitiveType.Capsule;
        }
    }
}
