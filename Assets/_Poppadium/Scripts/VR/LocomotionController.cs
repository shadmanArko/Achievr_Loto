using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LocomotionController : MonoBehaviour
{
    public XRController leftTeleportRay;
    public XRController rightTeleportRay;
    public InputHelpers.Button teleportActivationButton;
    public float activationThreshold = 0.1f;
    public GameObject teleportReticle;

    private void Update()
    {
        if (leftTeleportRay)
        {
            leftTeleportRay.gameObject.SetActive(CheckIfActivated(leftTeleportRay));
        }
        
        
        if (rightTeleportRay)
        {
            rightTeleportRay.gameObject.SetActive(CheckIfActivated(rightTeleportRay));
        }

        else
        {
            teleportReticle.SetActive(false);
        }
    }

    public bool CheckIfActivated(XRController controller)
    {
        controller.inputDevice.IsPressed(teleportActivationButton, out bool isActivated,
            activationThreshold);
        return isActivated;
    }
    
}
