using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    //public PrimaryButtonWatcher watcher;
    public bool IsPressed = false; // used to display button state in the Unity __Inspector__ window
    
    public bool showController = false;

    public GameObject handModelPrefab;

    public InputDeviceCharacteristics controllerCharacteristics;
    //public List<GameObject> controllerPrefabs;
    public GameObject controllerPrefab;
    private InputDevice _targetDevice;
    private GameObject _spawnedController;
    private GameObject _spawnedHandModel;

    private Animator _handAnimator;

    //public Laser laser;
    //private Laser _laserScript;

    //M4Shoot m4Shoot;
    //public GameObject m4;
    
    // Start is called before the first frame update
    void Start()
    {
        TryInitialize();
    }

    private void TryInitialize()
    {
        //_laserScript = laser.GetComponent<Laser>();

        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);

        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }

        if (devices.Count > 0)
        {
            _targetDevice = devices[0];
            //GameObject prefab = controllerPrefabs.Find(controller => controller.name == _targetDevice.name);
            GameObject prefab = controllerPrefab;
            if (prefab)
            {
                _spawnedController = Instantiate(prefab, transform);
            }
            // else
            // {
            //     Debug.LogError("Did not find the corresponding controller model");
            //     _spawnedController = Instantiate(controllerPrefabs[0], transform);
            // }

            _spawnedHandModel = Instantiate(handModelPrefab, transform);
            _handAnimator = _spawnedHandModel.GetComponent<Animator>(); //todo
        }

        //m4Shoot = _spawnedHandModel.GetComponent<M4Shoot>();
    }


    void UpdateHandAnimator()
    {
        if (_targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            _handAnimator.SetFloat("Trigger", triggerValue);
    
            if (triggerValue > .5)
            {
                Debug.Log("Trigger is pressed");
            }
        }
        else
        {
            _handAnimator.SetFloat("Trigger", 0);
        }
        
        if (_targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            _handAnimator.SetFloat("Grip", gripValue);
        }
        else
        {
            _handAnimator.SetFloat("Grip", 0);
        }
        
    }
    

    // Update is called once per frame
    void Update()
    {

        if (!_targetDevice.isValid)
        {
            TryInitialize();
        }
        else
        {
            if (showController)
            {
                _spawnedHandModel.SetActive(false);
                _spawnedController.SetActive(true);
            
            }
            else
            {
                _spawnedHandModel.SetActive(true);
                _spawnedController.SetActive(false);
                UpdateHandAnimator();
            }
        }
        
        // if (_targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue) && primaryButtonValue)
        // {
        //     Debug.Log("Pressing Primary Button");
        // }
        //
        // if (_targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue) && triggerValue > 0.1f)
        // {
        //     Debug.Log("Trigger Pressed " + triggerValue);
        // }
        //
        // if ( _targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2DAxisValue) && primary2DAxisValue != Vector2.zero)
        // {
        //     Debug.Log("Primary Touchpad " + primary2DAxisValue);
        // }

       
        
        

        // if (_targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButton) && primaryButton == true)
        // {
        //     //_laserScript.LaserOn();
        // }
        //
        // if (_targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        // {
        //     if (triggerValue > .5)
        //     {
        //        // m4Shoot.PullTheTrigger();
        //         _targetDevice.SendHapticImpulse(0, 1, 0.5f);
        //     }
        // }

    }
    
}
