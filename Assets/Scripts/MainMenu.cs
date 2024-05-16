using UnityEngine;
using UnityEngine.SceneManagement; // Needed for scene loading

public class MainMenu : MonoBehaviour
{
    public void StartTwoPlayers(int playerCount)
    {
        // Set the player count in the GameManager
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            gameManager.playerCount = playerCount; // Set the desired player count
            SceneManager.LoadSceneAsync(1); // Load GameScene (index 1)
        }
        else
        {
            SceneManager.LoadSceneAsync(1);
            Debug.LogError("GameManager script not found! Ensure it's present in the GameScene.");
        }
    }
    public void StartThreePlayers(int playerCount)
    {
        // Set the player count in the GameManager
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            gameManager.playerCount = playerCount; // Set the desired player count
            SceneManager.LoadSceneAsync(2); // Load GameScene (index 1)
        }
        else
        {
            SceneManager.LoadSceneAsync(2);
            Debug.LogError("GameManager script not found! Ensure it's present in the GameScene.");
        }
    }
    public void StartFourPlayers(int playerCount)
    {
        // Set the player count in the GameManager
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            gameManager.playerCount = playerCount; // Set the desired player count
            SceneManager.LoadSceneAsync(3); // Load GameScene (index 1)
        }
        else
        {
            SceneManager.LoadSceneAsync(3);
            Debug.LogError("GameManager script not found! Ensure it's present in the GameScene.");
        }
    }
    public void StartFivePlayers(int playerCount)
    {
        // Set the player count in the GameManager
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            gameManager.playerCount = playerCount; // Set the desired player count
            SceneManager.LoadSceneAsync(4); // Load GameScene (index 1)
        }
        else
        {
            SceneManager.LoadSceneAsync(4);
            Debug.LogError("GameManager script not found! Ensure it's present in the GameScene.");
        }
    }
    public void StartSixPlayers(int playerCount)
    {
        // Set the player count in the GameManager
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            gameManager.playerCount = playerCount; // Set the desired player count
            SceneManager.LoadSceneAsync(5); // Load GameScene (index 1)
        }
        else
        {
            SceneManager.LoadSceneAsync(5);
            Debug.LogError("GameManager script not found! Ensure it's present in the GameScene.");
        }
    }
}
