using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using TMPro;

public class EndManager : MonoBehaviour
{
    public GameObject clear;
    public GameObject over;

    public TMP_Text scoreText;
    public TMP_Text bestScoreText;

    public void Start()
    {
        if (DonDestory.instance.score >= DonDestory.instance.bestScore)
        {
            DonDestory.instance.bestScore = DonDestory.instance.score;
            PlayerPrefs.SetInt("BestScore", DonDestory.instance.bestScore);
        }
        if (DonDestory.instance.clear)
        {
            scoreText.text = "Score : " + DonDestory.instance.score.ToString();
            bestScoreText.text = "BestScore : " + DonDestory.instance.bestScore.ToString();
            over.gameObject.SetActive(false);
            clear.gameObject.SetActive(true);
        }
        else
        {
            scoreText.text = "Score : " + DonDestory.instance.score.ToString();
            bestScoreText.text = "BestScore : " + DonDestory.instance.bestScore.ToString();
            clear.gameObject.SetActive(false);
            over.gameObject.SetActive(true);
        }
    }
}
