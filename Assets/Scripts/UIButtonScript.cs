using UnityEngine;

public class UIButtonScript : MonoBehaviour
{
    private GameManager gm; // Private reference to GameManager script

    private void Start()
    {
        // Find GameManager script by name (more robust than assuming single instance)
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        // Handle potential GameManager not found scenario
        if (gm == null)
        {
            Debug.LogError("GameManager script not found! Ensure it's named 'GameManager' and present in the scene.");
        }
    }

    public void SwitchView()
    {
        
        if (gm != null)
        {
            if ((bool) gm.isMainCameraActive) // Access instance variable
            {
                gm.EnablePlayerCamera(gm.players[gm.currentPlayerIndex]); // Pass GameManager instance
            }
            else
            {
                gm.DisablePlayerCameras(); // Pass GameManager instance
            }
        }
        else
        {
            Debug.LogError("GameManager script not found! Ensure it's named 'GameManager' and present in the scene.");
        }
    }
}
