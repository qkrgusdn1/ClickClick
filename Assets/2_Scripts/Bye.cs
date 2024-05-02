using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bye : MonoBehaviour
{
    public ByeText byeText;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            byeText.gameObject.SetActive(true);
        }
    }
}
