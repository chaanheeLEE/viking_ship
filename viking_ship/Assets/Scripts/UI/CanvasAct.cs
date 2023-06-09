using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class CanvasAct : MonoBehaviour
{
    public GameObject canvas;
    public bool state;
    private InputDevice targetDevice;
    public GameObject Ray;

    void Start()
    {
        state = true;
        activateCanvas();
    }
    private void Update()
    {
        targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue);

        if (primaryButtonValue)
        {
            activateCanvas();
        }
    }

    public void activateCanvas()
    {
        if (state == true)
        {
            Ray.SetActive(false);
            canvas.SetActive(false);
            state = false;
        }
        else if (state == false)
        {
            Ray.SetActive(true);
            canvas.SetActive(true);
            state = true;
        }
    }
}
