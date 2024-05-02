using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ByeText : MonoBehaviour
{ 
    public TMP_Text tmpText;
    public string[] text;
    private int currentIndex;
    public void Start()
    {
        tmpText.text = text[0];
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            UpdateText();
        }
    }

    private void UpdateText()
    {
        currentIndex++;

        if (currentIndex >= text.Length)
        {
            SceneManager.LoadScene("Main");
            return;
        }
        tmpText.text = text[currentIndex];

    }
}
