using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    [SerializeField] private List<KeyCode> keyCodeList = new List<KeyCode>();
    [SerializeField]private List<KeyCode> removeKeyCodeList = new List<KeyCode>();

    private void Awake()
    {
        Instance = this;
    }

    public void AddKeyCode(KeyCode keyCode)
    {
        keyCodeList.Add(keyCode);
    }

    public void RemoveKeyCode(KeyCode keyCode)
    {
        removeKeyCodeList.Add(keyCode);
    }

    private void Update()
    {
        if (GameManager.Instance.IsGameDone)
        {
            return;
        }
        foreach (KeyCode keyCode in keyCodeList)
        {
            if (Input.GetKeyDown(keyCode) == true)
            {
                NoteManager.Instance.OnInput(keyCode);
                break;
            }
        }
        foreach (KeyCode removeKeyCode in removeKeyCodeList)
        {
            if (Input.GetKeyDown(removeKeyCode) == true)
            {
                NoteManager.Instance.RemoveInput(removeKeyCode);
                break;
            }
        }
    }
}
