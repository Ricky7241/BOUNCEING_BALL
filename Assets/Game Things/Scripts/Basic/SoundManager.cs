using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set; }
    private AudioSource soundSource;
    private AudioSource musicSource;

    private void Awake()
    {
        soundSource = GetComponent<AudioSource>();
        musicSource = transform.GetChild(0).GetComponent<AudioSource>();

        // Ensure only one instance of AudioManager exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Set initial volume levels
        SetMusicVolume(0);
        SetSoundVolume(0);
    }

    // Play a sound effect
    public void PlaySound(AudioClip sound)
    {
        soundSource.PlayOneShot(sound);
    }

    // Adjust sound effect volume
    public void SetSoundVolume(float change)
    {
        SetVolume(1, "SoundVolume", change, soundSource);
    }

    // Adjust music volume
    public void SetMusicVolume(float change)
    {
        SetVolume(0.3f, "MusicVolume", change, musicSource);
    }

    // General method to adjust volume
    private void SetVolume(float baseVolume, string volumeName, float change, AudioSource source)
    {
        // Retrieve current volume setting and apply change
        float currentVolume = PlayerPrefs.GetFloat(volumeName, 1);
        currentVolume += change;

        // Ensure volume remains within bounds
        if (currentVolume > 1)
            currentVolume = 0;
        else if (currentVolume < 0)
            currentVolume = 1;

        // Set final volume
        float finalVolume = currentVolume * baseVolume;
        source.volume = finalVolume;

        // Save new volume setting
        PlayerPrefs.SetFloat(volumeName, currentVolume);
    }
}
