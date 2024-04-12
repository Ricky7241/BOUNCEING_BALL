using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health playerHealth; // Reference to the player's health component
    [SerializeField] private Image totalHealthBar; // Reference to the total health bar image
    [SerializeField] private Image currentHealthBar; // Reference to the current health bar image

    private void Start()
    {
        totalHealthBar.fillAmount = playerHealth.currentHealth / 10f; // Set total health bar fill amount
    }

    private void Update()
    {
        currentHealthBar.fillAmount = playerHealth.currentHealth / 10f; // Set current health bar fill amount
    }
}
