using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public AudioClip sfxClip; // assign in Inspector
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySFX()
    {
        audioSource.PlayOneShot(sfxClip);
    }
}
