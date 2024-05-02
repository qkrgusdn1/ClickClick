using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip[] audioClips;
    public AudioSource audioSource;
    public static SoundManager instance;
    private void Awake()
    {
        instance = this;
    }

    public void Sound(int sound)
    {
        audioSource.clip = audioClips[sound];
        audioSource.Play();
    }

    private void Start()
    {
        Sound(0);
    }
}
