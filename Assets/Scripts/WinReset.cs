using UnityEngine;
using UnityEngine.SceneManagement;

public class WinReset : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if colliding object has the "Player" tag
        if (collision.collider.CompareTag("Player"))
        {
            // Load scene with index 6 asynchronously
            SceneManager.LoadSceneAsync(6);
        }
    }
}
