using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class XRControllerInput : MonoBehaviour
{
    private InputAction primaryButtonAction;
    public CanvasAct acter;

    private void Start()
    {
        // primary button 입력 액션 생성
        primaryButtonAction = new InputAction("PrimaryButton", binding: "<XRController>{LeftHand}/primaryButton");
        primaryButtonAction.Enable();
        primaryButtonAction.started += OnPrimaryButtonStarted;
        primaryButtonAction.performed += OnPrimaryButtonPerformed;
        primaryButtonAction.canceled += OnPrimaryButtonCanceled;
    }

    private void OnDestroy()
    {
        // 액션 사용 종료
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
