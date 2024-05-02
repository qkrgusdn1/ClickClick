using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public void Idle()
    {
        GameManager.Instance.appleAni.Play("Idle");
    }
}
