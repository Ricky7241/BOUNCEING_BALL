using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider that entered is the player
        if (other.CompareTag("Player"))
        {
            // Handle the event when the player touches the trigger
            Debug.Log("Player touched the level complete trigger!");

            // Example: Load the next level
            SceneManager.LoadScene(0);
        }
    }
}
