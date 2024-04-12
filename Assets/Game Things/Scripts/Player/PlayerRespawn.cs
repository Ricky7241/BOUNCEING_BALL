using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private AudioClip checkpoint; // Sound effect for reaching a checkpoint
    private Transform currentCheckpoint; // Current checkpoint position
    private Health playerHealth; // Player's health component
    private UIManager uiManager; // Reference to the UI manager

    private void Awake()
    {
        playerHealth = GetComponent<Health>();
        uiManager = FindObjectOfType<UIManager>();
    }

    public void RespawnCheck()
    {
        if (currentCheckpoint == null)
        {
            uiManager.GameOver(); // Display game over screen if no checkpoint is set
            return;
        }
        playerHealth.Respawn(); // Restore player health and reset animation
        transform.position = currentCheckpoint.position; // Move player to checkpoint location

        PlayerController playerController = GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.enabled = true;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Checkpoint"))
        {
            currentCheckpoint = collision.transform; // Set current checkpoint
            SoundManager.instance.PlaySound(checkpoint); // Play checkpoint sound
            collision.GetComponent<Collider2D>().enabled = false; // Disable collider to prevent multiple triggers
            collision.GetComponent<Animator>().SetTrigger("appear"); // Trigger appearance animation
        }
    }
}
