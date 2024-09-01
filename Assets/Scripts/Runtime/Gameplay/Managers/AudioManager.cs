using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    private void Start()
    {
        AudioEvents.PlaySound += PlaySound;
        AudioEvents.StopSound += StopSound;
    }

    private void OnDestroy()
    {
        AudioEvents.PlaySound -= PlaySound;
        AudioEvents.StopSound -= StopSound;
    }

    private void PlaySound()
    {
        if (!audioSource.isPlaying) // Eğer ses çalmıyorsa
        {
            audioSource.Play();
        }
    }

    private void StopSound()
    {
        if (audioSource.isPlaying) // Eğer ses çalıyorsa
        {
            audioSource.Stop();
        }
    }
}