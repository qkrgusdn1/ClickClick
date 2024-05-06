using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonDestory : MonoBehaviour
{
    public int score;
    public int bestScore;
    public static DonDestory instance;
    public bool clear;
    public float musicVolume;
    public AudioSource musicAudioSource;
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        musicAudioSource = GetComponent<AudioSource>();
        musicAudioSource.volume = musicVolume;
    }

}
