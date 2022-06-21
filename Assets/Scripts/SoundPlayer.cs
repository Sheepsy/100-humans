using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip[] deathSounds;
    [SerializeField] private AudioClip[] huhSounds;
    [SerializeField] private AudioClip[] joySounds;
    [SerializeField] private AudioClip[] yuckSounds;
    [SerializeField] private AudioClip[] yumSounds;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayDeathSound(float pitch)
    {
        audioSource.pitch = pitch;
        audioSource.PlayOneShot(deathSounds[Random.Range(0, deathSounds.Length)]);
    }

    public void PlayHuhSound(float pitch)
    {
        audioSource.pitch = pitch;
        audioSource.PlayOneShot(huhSounds[Random.Range(0, huhSounds.Length)]);
    }
    
    public void PlayJoySound(float pitch)
    {
        audioSource.pitch = pitch;
        audioSource.PlayOneShot(joySounds[Random.Range(0, joySounds.Length)]);
    }

    public void PlayYuckSound(float pitch)
    {
        audioSource.pitch = pitch;
        audioSource.PlayOneShot(yuckSounds[Random.Range(0, yuckSounds.Length)]);
    }

    public void PlayYumSound(float pitch)
    {
        audioSource.pitch = pitch;
        audioSource.PlayOneShot(yumSounds[Random.Range(0, yumSounds.Length)]);
    }
}
