using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class XRControllerInput_R : MonoBehaviour
{
    private InputAction primaryButtonAction;
    public Attack acter;

    private void Start()
    {
        // primary button �Է� �׼� ����
        primaryButtonAction = new InputAction("PrimaryButton", binding: "<XRController>{RightHand}/primaryButton");
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
        acter.Attack_();
    }

    private void OnPrimaryButtonPerformed(InputAction.CallbackContext context)
    {

    }

    private void OnPrimaryButtonCanceled(InputAction.CallbackContext context)
    {

    }
}
