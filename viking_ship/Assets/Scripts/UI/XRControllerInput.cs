using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class XRControllerInput : MonoBehaviour
{
    private InputAction primaryButtonAction;
    public CanvasAct acter;

    private void Start()
    {
        // primary button �Է� �׼� ����
        primaryButtonAction = new InputAction("PrimaryButton", binding: "<XRController>{LeftHand}/primaryButton");
        primaryButtonAction.Enable();
        primaryButtonAction.started += OnPrimaryButtonStarted;
        primaryButtonAction.performed += OnPrimaryButtonPerformed;
        primaryButtonAction.canceled += OnPrimaryButtonCanceled;
    }

    private void OnDestroy()
    {
        // �׼� ��� ����
        primaryButtonAction.Disable();
        primaryButtonAction.started -= OnPrimaryButtonStarted;
        primaryButtonAction.performed -= OnPrimaryButtonPerformed;
        primaryButtonAction.canceled -= OnPrimaryButtonCanceled;
    }

    private void OnPrimaryButtonStarted(InputAction.CallbackContext context)
    {
        acter.activateCanvas();
    }

    private void OnPrimaryButtonPerformed(InputAction.CallbackContext context)
    {

    }

    private void OnPrimaryButtonCanceled(InputAction.CallbackContext context)
    {

    }
}
