using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    #region Fields

    public GameObject handModelPrefab;
    public InputDeviceCharacteristics controllerCharacteristics;

    private InputDevice _targetDevice;
    private GameObject _spawnedController;
    private GameObject _spawnedHandModel;
    private Animator _handAnimator;

    #endregion


    #region Methods

    void Start()
    {
        TryInitialize();
    }

    private void TryInitialize()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);
        

        if (devices.Count > 0)
        {
            _targetDevice = devices[0];
            _spawnedHandModel = Instantiate(handModelPrefab, transform);
        }
        
    }
    
    #endregion
    
}
