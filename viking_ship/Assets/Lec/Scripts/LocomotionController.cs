using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class LocomotionController : MonoBehaviour
{
    public InputActionReference teleportReference = null;
    public GameObject teleportRay;
    public bool EnableTeleport { get; set; } = true;

    private float value;
    public XRRayInteractor rayInteractor;

    private void Update()
    {
        float value = teleportReference.action.ReadValue<float>();
        if(value > 0.1f && EnableTeleport)
        {
            Vector3 pos; Vector3 norm; int index; bool validTarget;
            bool isInteractorRayHovering = rayInteractor.TryGetHitInfo(out pos, out norm, out index, out validTarget);
            if(!isInteractorRayHovering)
            {
                teleportRay.SetActive(true);
            }
        }
        else
        {
            teleportRay.SetActive(false);
        }
    }
}
