using UnityEngine;
using System.Collections;// For using InputSystem

public class PlayerCameraSwitch : MonoBehaviour
{
    public Camera mainCamera; // Reference to the main camera
    public Camera playerCamera; // Reference to the player camera (child camera)

    private bool isPlayerCameraActive = false;

    private void Start()
    {
        if (mainCamera == null)
        {
            Debug.LogError("No main camera assigned to PlayerCameraSwitch script on " + gameObject.name);
        }

        if (playerCamera == null)
        {
            Debug.LogError("No player camera assigned to PlayerCameraSwitch script on " + gameObject.name);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V)) // Check for V key press using InputSystem
        {
            isPlayerCameraActive = !isPlayerCameraActive; // Toggle camera state

            mainCamera.enabled = !isPlayerCameraActive;
            playerCamera.enabled = isPlayerCameraActive;
        }
    }
}
