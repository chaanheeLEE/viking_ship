using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class XRControllerInput_R : MonoBehaviour
{
    private InputAction primaryButtonAction;
    public Attack acter;

    private void Start()
    {
        // primary button 입력 액션 생성
        primaryButtonAction = new InputAction("PrimaryButton", binding: "<XRController>{RightHand}/primaryButton");
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
        acter.Attack_();
    }

    private void OnPrimaryButtonPerformed(InputAction.CallbackContext context)
    {

    }

    private void OnPrimaryButtonCanceled(InputAction.CallbackContext context)
    {

    }
}
