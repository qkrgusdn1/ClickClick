using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    int score;
    int nextNoteGroupUnlockCnt;

    [SerializeField] private int maxScore = 100;
    [SerializeField] private int noteGroupCreateScore = 10;
    [SerializeField] private GameObject gameClearObj;
    [SerializeField] private GameObject gameOverObj;
    [SerializeField] private float maxTime;
    float currentTime;
    [SerializeField] private float minusTime;

    public Animator appleAni;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UIManager.Instance.OnScoreChange(score, maxScore);

        NoteManager.Instance.Create();

        gameClearObj.SetActive(false);
        gameOverObj.SetActive(false);
        StartCoroutine(TimerCoroutine());
    }


    public void CalForRemoveScore(Notetype _noteType)
    {
        if (_noteType == Notetype.Apple)
        {
            appleAni.Play("Sad", -1, 0);
            score--;
            DonDestory.instance.score--;
        }
        else if (_noteType == Notetype.Blueberry)
        {
            appleAni.Play("Happy", -1, 0);
            score++;
            DonDestory.instance.score++;

            nextNoteGroupUnlockCnt++;

            if (noteGroupCreateScore <= nextNoteGroupUnlockCnt)
            {
                nextNoteGroupUnlockCnt = 0;
                NoteManager.Instance.CreateNoteGroup();
            }

            if (maxScore <= score)
            {
                DonDestory.instance.clear = true;
                SceneManager.LoadScene("EndGame");
            }
        }
        else if (_noteType == Notetype.Clock)
        {
            appleAni.Play("HHPPYY", -1, 0);
            if (currentTime >= 0)
            {
                currentTime -= minusTime;
                if (currentTime <= 0)
                {
                    currentTime = 0;
                }
                UIManager.Instance.OnTimerChange(currentTime, maxTime);
            }

        }

        UIManager.Instance.OnScoreChange(score, maxScore);
    }
    public void CalculateScore(Notetype _noteType)
    {
        if (_noteType == Notetype.Apple)
        {
            appleAni.Play("Happy", -1, 0);
            score++;
            DonDestory.instance.score++;

            nextNoteGroupUnlockCnt++;

            if (noteGroupCreateScore <= nextNoteGroupUnlockCnt)
            {
                nextNoteGroupUnlockCnt = 0;
                NoteManager.Instance.CreateNoteGroup();
            }

            if (maxScore <= score)
            {
                DonDestory.instance.clear = true;
                SceneManager.LoadScene("EndGame");
            }
        }
        else if (_noteType == Notetype.Blueberry)
        {
            appleAni.Play("Sad", -1, 0);
            score--;
            DonDestory.instance.score--;
        }
        else if (_noteType == Notetype.Clock)
        {
            appleAni.Play("HHAAPPYY", -1, 0);
            if (currentTime >= 0)
            {
                currentTime -= minusTime;
                if (currentTime <= 0)
                {
                    currentTime = 0;
                }
                UIManager.Instance.OnTimerChange(currentTime, maxTime);
            }

        }

        UIManager.Instance.OnScoreChange(score, maxScore);
    }
    public bool IsGameDone
    {
        get
        {
            if (gameClearObj.activeSelf || gameOverObj.activeSelf)
                return true;
            else
                return false;
        }
    }
    IEnumerator TimerCoroutine()
    {


        while (currentTime < maxTime)
        {
            currentTime += Time.deltaTime;
            UIManager.Instance.OnTimerChange(currentTime, maxTime);
            yield return null;

            if (IsGameDone)
            {
                yield break;
            }
        }
        DonDestory.instance.clear = false;
        SceneManager.LoadScene("EndGame");
    }
}
