using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRGrabInteractableOffset : XRGrabInteractable
{
    // Transform 자체는 Monobehavior이므로 deep copy하려면 비용이 높을 것
    // 단순히 Vector3(struct), Quaternion(struct)를 저장하는 것이 더 효율적
    private Vector3 initialAttachPos;
    private Quaternion initialAttachRot;

    private void Start()
    {
        if(!attachTransform)
        {
            GameObject grabPivot = new GameObject("Grab Pivot");
            grabPivot.transform.SetParent(this.transform, false);
            attachTransform = grabPivot.transform;
        }

        initialAttachPos = attachTransform.localPosition;
        initialAttachRot = attachTransform.localRotation;
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (args.interactorObject is XRDirectInteractor)
        {
            attachTransform.position = args.interactorObject.transform.position;
            attachTransform.rotation = args.interactorObject.transform.rotation;
        }

        base.OnSelectEntered(args);
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        if (args.interactorObject is XRDirectInteractor)
        {
            attachTransform.localPosition = initialAttachPos;
            attachTransform.localRotation = initialAttachRot;
        }
        base.OnSelectExited(args);
    }
}
