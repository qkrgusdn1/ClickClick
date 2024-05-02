using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Start : MonoBehaviour
{
    public void ClickBtn()
    {
        DonDestory.instance.score = 0;
        SceneManager.LoadScene("Bye");
    }

    public void RePlay()
    {
        SceneManager.LoadScene("Main");
    }

    public void GameExit()
    {
        Application.Quit();
    }
}
