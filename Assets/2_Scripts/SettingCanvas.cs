using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingCanvas : MonoBehaviour
{
    public Slider slider;
    public static SettingCanvas instance;
    private void Awake()
    {
        instance = this;
    }

    private void OnEnable()
    {
        slider.value = DonDestory.instance.musicVolume;
    }

    public void MusicVolumeSlider(float volume)
    {
        PlayerPrefs.SetFloat("MusicVolume", slider.value);
        //�� ���� �������� �Ҹ������ϴ� �ڵ�
        DonDestory.instance.musicAudioSource.volume = slider.value;
        DonDestory.instance.musicVolume = slider.value;
    }
}
