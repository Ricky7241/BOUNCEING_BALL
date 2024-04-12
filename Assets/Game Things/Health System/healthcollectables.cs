using UnityEngine;

public class healthcollectables : MonoBehaviour
{
    [SerializeField] private float healthRestored; // Amount of health restored
    [SerializeField] private AudioClip pickupClip; // Sound effect for pickup

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SoundManager.instance.PlaySound(pickupClip); // Play pickup sound
            other.GetComponent<Health>().AddHealth(healthRestored); // Increase player's health
            gameObject.SetActive(false); // Deactivate pickup object
        }
    }
}
