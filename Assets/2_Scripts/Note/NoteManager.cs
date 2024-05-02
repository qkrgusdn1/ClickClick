using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    [SerializeField] private GameObject noteGroupPrefab;
    [SerializeField] private float noteGroup;
    [SerializeField] private float noteGroupGap;

    private KeyCode[] wholeiKeycodeArr = new KeyCode[]
    {
        KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.F, 
        KeyCode.G, KeyCode.H, KeyCode.J, KeyCode.K, KeyCode.L
    };
    private KeyCode[] removeKeycodeArr = new KeyCode[]
    {
        KeyCode.Z, KeyCode.X, KeyCode.C, KeyCode.V,
        KeyCode.B, KeyCode.N, KeyCode.M, KeyCode.Comma, KeyCode.Period
    };
    [SerializeField] private int InitNoteGroupNum = 2;
    public static NoteManager Instance;
    private List<NoteGroup> noteGroupList = new List<NoteGroup>();
    
    public void Create()
    {
        for(int i = 0; i < InitNoteGroupNum; i++)
        {
            CreateNoteGroup(wholeiKeycodeArr[i], removeKeycodeArr[i]);
        }

    }

    public void CreateNoteGroup()
    {
        int noteGroupCount = noteGroupList.Count;
        if (wholeiKeycodeArr.Length == noteGroupCount)
            return;
        KeyCode keyCode = wholeiKeycodeArr[noteGroupCount];
        KeyCode removeKeyCode = removeKeycodeArr[noteGroupCount];
        CreateNoteGroup(keyCode, removeKeyCode);
    }

    void CreateNoteGroup(KeyCode keyCode , KeyCode removeKeyCode)
    {
        GameObject noteGroupObj = Instantiate(noteGroupPrefab);
        noteGroupObj.transform.position = (Vector3.right * noteGroupList.Count * noteGroupGap) + new Vector3(0, 4.5f);

        NoteGroup noteGroup = noteGroupObj.GetComponent<NoteGroup>();
        noteGroup.Create(keyCode, removeKeyCode);

        noteGroupList.Add(noteGroup);
    }

    private void Awake()
    {
        Instance = this;
    }
    public void RemoveInput(KeyCode keyCode)
    {
        Debug.Log("R");
        Notetype notetype = Notetype.Apple;
        //사과 60%, 블루베리30% 상자 10%
        float random = Random.Range(0, 100);
        if (random < 60)
        {
            notetype = Notetype.Apple;
        }
        else if (random < 90)
        {
            notetype = Notetype.Blueberry;
        }
        else if (random <= 100)
        {
            notetype = Notetype.Clock;
        }

        foreach (NoteGroup noteGroup in noteGroupList)
        {
            if (keyCode == noteGroup.RemoveKeyCode)
            {
                noteGroup.RemoveInput(notetype);
                break;
            }
        }
    }
    public void OnInput(KeyCode keyCode)
    {
        Debug.Log("O");
        Notetype notetype = Notetype.Apple;
        //사과 60%, 블루베리30% 상자 10%
        float random = Random.Range(0, 100);
        if (random < 60)
        {
            notetype = Notetype.Apple;
        }
        else if (random < 90)
        {
            notetype = Notetype.Blueberry;
        }
        else if(random <= 100)
        {
            notetype = Notetype.Clock;
        }

        foreach (NoteGroup noteGroup in noteGroupList)
        {
            if(keyCode == noteGroup.KeyCode)
            {
                noteGroup.OnInput(notetype);
                break;
            }
        }
    }
}
