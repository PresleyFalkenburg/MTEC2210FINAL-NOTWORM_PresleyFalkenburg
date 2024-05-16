using UnityEngine;
using UnityEngine.SceneManagement; // Needed for scene loading

public class PlayAgainMenu : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadSceneAsync(0);
    }

}