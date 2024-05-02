using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NoteGroup : MonoBehaviour
{
    [SerializeField] private int noteMaxNum = 5;
    [SerializeField] private GameObject notePrefab = null;
    [SerializeField] private GameObject noteSpawn;

    [SerializeField] private SpriteRenderer btnSpriteRenderer;
    [SerializeField] private Sprite normalBtnSprite;
    [SerializeField] private Sprite selectBtnSprite;
    [SerializeField] private TextMeshPro keyCodeTmp;
    [SerializeField] private TextMeshPro removeKeyCodeTmp;
    [SerializeField] private Animator anim;
    private KeyCode keyCode;
    private KeyCode removeKeyCode;
    public List<Note> noteList = new List<Note>();
    public float noteGap;

    

    private void Start()
    {
        GameManager.Instance.appleAni.Play("Clap",-1, 0);
    }

    public KeyCode KeyCode
    {
        get
        {
            return keyCode;
        }
    }
    public KeyCode RemoveKeyCode
    {
        get
        {
            return removeKeyCode;
        }
    }
    public void Create(KeyCode keyCode, KeyCode removeKeyCode)
    {
        this.keyCode = keyCode;
        this.removeKeyCode = removeKeyCode;

        keyCodeTmp.text = keyCode.ToString();
        
        if(removeKeyCode == KeyCode.Comma)
        {
            removeKeyCodeTmp.text = ",";
        }
        else if(removeKeyCode == KeyCode.Period)
        {
            removeKeyCodeTmp.text = ".";
        }
        else
        {
            removeKeyCodeTmp.text = removeKeyCode.ToString();
        }

        for (int i = 0; i < noteMaxNum; i++)
        {
            CreateNote(Notetype.Apple);
        }

        InputManager.Instance.AddKeyCode(KeyCode);
        InputManager.Instance.RemoveKeyCode(RemoveKeyCode);
    }

    void CreateNote(Notetype notetype)
    {
        GameObject noteGameObj = Instantiate(notePrefab);
        noteGameObj.transform.SetParent(noteSpawn.transform);

        noteGameObj.transform.localPosition = Vector3.up * this.noteList.Count * noteGap;

        Note note = noteGameObj.GetComponent<Note>();
        note.SetSprite(notetype);
        noteList.Add(note);
    }
    public void RemoveInput(Notetype notetype)
    {
        Note delnote = noteList[0];
        delnote.CalRemoveAnDeleteNote();
        noteList.RemoveAt(0);

        for (int i = 0; i < noteList.Count; i++)
            noteList[i].transform.localPosition = Vector3.up * i * noteGap;
        CreateNote(notetype);
        anim.Play("RmoveNoteGroup", -1, 0);
    }
    public void OnInput(Notetype notetype)
    {
        Note delnote = noteList[0];
        delnote.CalScoreAndDeleteNote();
        noteList.RemoveAt(0);

        for (int i = 0; i < noteList.Count; i++)
            noteList[i].transform.localPosition = Vector3.up * i * noteGap;
        CreateNote(notetype);
        anim.Play("NoteGroupBtn", -1, 0);
        btnSpriteRenderer.sprite = selectBtnSprite;
    }

    public void CallAniDone()
    {
        btnSpriteRenderer.sprite = normalBtnSprite;
    }
}
