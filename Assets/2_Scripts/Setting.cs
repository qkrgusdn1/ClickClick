using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{

    public SettingCanvas settingCanvas;
    public void Exit()
    {
        settingCanvas.gameObject.SetActive(false);
    }
    public void InSetting()
    {
        settingCanvas.gameObject.SetActive(true);
    }
}
