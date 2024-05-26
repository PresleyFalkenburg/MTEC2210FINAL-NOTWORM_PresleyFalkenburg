using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int playerCount = 0; // Number of players set in the inspector
    public GameObject[] playerPrefabs; // Array of player prefabs to spawn
    public float spawnAreaXMin = -5f; // Minimum X position for spawn area
    public float spawnAreaXMax = 5f; // Maximum X position for spawn area
    public float TurnTimer = 25f;
    public int currentPlayerIndex = 0;
    public GameObject[] players;
    public bool isMainCameraActive = true; // Flag to track current view (true = main camera, false = player camera)

    public void Start()
    {
        SpawnPlayers();
        StartCoroutine(ManageTurns());
    }

    private void SpawnPlayers()
    {
        players = new GameObject[playerCount];

        for (int i = 0; i < playerCount; i++)
        {
            // Generate random X position within the spawn area
            float randomX = Random.Range(spawnAreaXMin, spawnAreaXMax);

            // Spawn player at random X and fixed Y position
            players[i] = Instantiate(playerPrefabs[i], new Vector3(randomX, -20f, 0f), Quaternion.identity);
            players[i].GetComponent<PlayerMovement>().enabled = false;
            players[i].GetComponentInChildren<PlayerActionManager>().enabled = false;
            SetupPlayerCamera(players[i]); // Call new function to setup camera
        }
    }

    private void SetupPlayerCamera(GameObject player)
    {
        // Find the child object with the Camera component
        Camera playerCamera = player.GetComponentInChildren<Camera>();
        if (playerCamera != null)
        {
            playerCamera.enabled = false; // Initially disable all player cameras
        }
    }

    private IEnumerator ManageTurns()
    {
        while (true)
        {
            players[currentPlayerIndex].GetComponent<PlayerMovement>().enabled = true;
            players[currentPlayerIndex].GetComponentInChildren<PlayerActionManager>().enabled = true;
            players[currentPlayerIndex].GetComponentInChildren<UIButtonScript>().enabled = true;
            players[currentPlayerIndex].GetComponentInChildren<Canvas>().enabled = true;
            EnablePlayerCamera(players[currentPlayerIndex]); // Enable current player camera

            yield return new WaitForSeconds(TurnTimer);
            //call function that reset the UI progress bar

            Debug.Log("Turn Switch");
            players[currentPlayerIndex].GetComponent<PlayerMovement>().enabled = false;
            players[currentPlayerIndex].GetComponentInChildren<PlayerActionManager>().enabled = false;
            players[currentPlayerIndex].GetComponentInChildren<UIButtonScript>().enabled = false;
            players[currentPlayerIndex].GetComponentInChildren<Canvas>().enabled = false;
            DisablePlayerCameras(); // Disable all player cameras

            currentPlayerIndex++;

            if (currentPlayerIndex >= playerCount)
            {
                currentPlayerIndex = 0;
            }
        }
    }

    public void EnablePlayerCamera(GameObject player)
    {
        Camera playerCamera = player.GetComponentInChildren<Camera>();
        if (playerCamera != null)
        {
            // Enable the current player's camera
            playerCamera.enabled = true;
            isMainCameraActive = false; // Update view state
        }
    }

    public void DisablePlayerCameras()
    {
        foreach (GameObject player in players)
        {
            Camera playerCamera = player.GetComponentInChildren<Camera>();
            if (playerCamera != null)
        {
                playerCamera.enabled = false;
            }
        }
        isMainCameraActive = true; // Update view state
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            // Toggle camera view based on current state
            if (isMainCameraActive)
            {
                EnablePlayerCamera(players[currentPlayerIndex]);
            }
            else
            {
                DisablePlayerCameras();
            }
        }
    }
    
}
