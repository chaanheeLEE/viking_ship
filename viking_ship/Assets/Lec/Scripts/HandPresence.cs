using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    public enum Handiness { LEFT, RIGHT };

    public bool showController = false;
    public InputDeviceCharacteristics ControllerCharacteristic;
    public List<GameObject> controllerModelPrefabs;
    public List<GameObject> handModelPrefabs;

    private InputDevice targetDevice;
    private GameObject spawnedControllerModel;
    private GameObject spawnedHandModel;
    private Animator handAnimator;

    void Start()
    {
        // Quest 2의 경우 앱 시작시에는 컨트롤러가 거의 반드시 슬립 상태이므로 Update()에서도 장치 인식 필요
        TryInitialize(ControllerCharacteristic);
    }

    void Update()
    {
        if (!targetDevice.isValid)
        {
            TryInitialize(ControllerCharacteristic);
            return;
        }

        VisualizeModel();

        //--- 입력 핸들링 테스트 
        // 버튼 입력 Pooling
        if(targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primartButtonValue) && primartButtonValue)
        {
            Debug.Log("Pressing Primary Button");
        }

        // Trigger 입력 Pooling
        if(targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue) && triggerValue > 0.1f) // Trigger 입력은 float임
        {
            Debug.Log("Pressing Trigger : " + triggerValue);
        }

        // Axis 입력 Pooling
        if (targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 axisValue) && axisValue != Vector2.zero) // Axis 입력은 Vector2임
        {
            Debug.Log("Axis : " + axisValue);
        }
    }

    void VisualizeModel()
    {
        if (showController)
        {
            spawnedHandModel.SetActive(false);
            spawnedControllerModel.SetActive(true);
        }
        else
        {
            spawnedHandModel.SetActive(true);
            spawnedControllerModel.SetActive(false);

            // 손 모델인 경우 입력에 따른 손 애니메이션 적용
            UpdateHandAnimation();
        }
    }

    void TryInitialize(InputDeviceCharacteristics cha)
    {
        Debug.Log("Trying to get controller...");

        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(cha, devices);

        //foreach (var item in devices)
        //{
        //    Debug.Log(item.name + item.characteristics);
        //}

        if(devices.Count > 0)
        {
            Debug.Log("Got controller!");
            targetDevice = devices[0];

            if(targetDevice.name.Contains("Left"))
            {
                SpawnModels(Handiness.LEFT);
            }
            if (targetDevice.name.Contains("Right"))
            {
                SpawnModels(Handiness.RIGHT);
            }
        }
    }

    void SpawnModels(Handiness handiness)
    {
        GameObject controllerPrefab = null;
        GameObject handPrefab = null;
        if (handiness == Handiness.LEFT)
        {
            controllerPrefab = controllerModelPrefabs.Find(controller => controller.name.Contains("Left"));
            handPrefab = handModelPrefabs.Find(hand => hand.name.Contains("Left"));
        }
        if (handiness == Handiness.RIGHT)
        {
            controllerPrefab = controllerModelPrefabs.Find(controller => controller.name.Contains("Right"));
            handPrefab = handModelPrefabs.Find(hand => hand.name.Contains("Right"));
        }

        if (controllerPrefab)
        {
            spawnedControllerModel = Instantiate(controllerPrefab, this.transform);
        }
        if(handPrefab)
        {
            spawnedHandModel = Instantiate(handPrefab, this.transform);
            handAnimator = spawnedHandModel.GetComponent<Animator>();
        }
    }

    void UpdateHandAnimation()
    {
        if(targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            handAnimator.SetFloat("Trigger", triggerValue);
        }
        else
        {
            handAnimator.SetFloat("Trigger", 0);
        }

        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            handAnimator.SetFloat("Grip", gripValue);
        }
        else
        {
            handAnimator.SetFloat("Grip", 0);
        }
    }
}
