using UnityEngine;
using System.Collections;

public class BlazePit : MonoBehaviour
{
    [SerializeField] private float damage; // Damage inflicted by the blaze pit

    [Header("Timers")]
    [SerializeField] private float activationDelay; // Delay before activation
    [SerializeField] private float activeTime; // Duration of activation
    private Animator anim; // Animator component
    private SpriteRenderer spriteRenderer; // Sprite renderer component

    [Header("Sound Effects")]
    [SerializeField] private AudioClip fireSound; // Sound effect for activation

    private bool triggered; // Flag for activation
    private bool active; // Flag for active state

    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!triggered)
                StartCoroutine(ActivateBlazePit());

            if (active)
                collision.GetComponent<Health>().TakeDamage(damage);
        }
    }

    private IEnumerator ActivateBlazePit()
    {
        triggered = true;
        spriteRenderer.color = Color.red;

        yield return new WaitForSeconds(activationDelay);
        SoundManager.instance.PlaySound(fireSound);
        spriteRenderer.color = Color.white;
        active = true;
        anim.SetBool("activated", true);

        yield return new WaitForSeconds(activeTime);
        active = false;
        triggered = false;
        anim.SetBool("activated", false);
    }
}
