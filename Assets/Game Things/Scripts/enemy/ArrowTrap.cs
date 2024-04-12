using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    [SerializeField] private GameObject arrowPrefab; // Prefab of the arrow to be shot
    [SerializeField] private Transform shootPoint; // Point from where the arrow will be shot
    [SerializeField] private float shootInterval = 2f; // Interval between each shot
    [SerializeField] private AudioClip shootingSound; // Sound effect for shooting

    private bool canShoot = true; // Flag to determine if the trap can shoot

    private void Start()
    {
        InvokeRepeating(nameof(ShootArrow), shootInterval, shootInterval); // Start shooting arrows at intervals
    }

    private void ShootArrow()
    {
        if (!canShoot)
            return;

        if (arrowPrefab != null && shootPoint != null)
        {
            GameObject arrow = Instantiate(arrowPrefab, shootPoint.position, shootPoint.rotation);
            Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = shootPoint.right * 10f; // Adjust the arrow's velocity as needed
            }

            if (shootingSound != null)
            {
                SoundManager.instance.PlaySound(shootingSound); // Play shooting sound
            }
        }
    }

    // Optionally, you can add methods to enable/disable shooting based on certain conditions
    public void EnableShooting()
    {
        canShoot = true;
    }

    public void DisableShooting()
    {
        canShoot = false;
    }
}
