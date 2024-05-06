using UnityEngine;

public class Note : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite appleSprite;
    [SerializeField] Sprite bileberrySprite;
    [SerializeField] Sprite colckSprite;
    Notetype notetype;
    public void CalScoreAndDeleteNote()
    {
        GameManager.Instance.CalculateScore(notetype);
        if (notetype == Notetype.Apple || notetype == Notetype.Clock)
        {
            SoundManager.instance.Sound(0);
        }
        else if(notetype == Notetype.Blueberry)
        {
            SoundManager.instance.Sound(1);
        }
        Destroy(gameObject);

    }
    public void CalRemoveAnDeleteNote()
    {
        GameManager.Instance.CalForRemoveScore(notetype);
        if (notetype == Notetype.Apple || notetype == Notetype.Clock)
        {
            SoundManager.instance.Sound(0);
        }
        else if (notetype == Notetype.Blueberry)
        {
            SoundManager.instance.Sound(1);
        }
        Destroy(gameObject);
    }

    public void SetSprite(Notetype notetype)
    {
        this.notetype = notetype;
        if (notetype == Notetype.Apple)
        {
            spriteRenderer.sprite = appleSprite;
        }
        else if (notetype == Notetype.Blueberry)
        {
            spriteRenderer.sprite = bileberrySprite;
        }
        else if (notetype == Notetype.Clock)
        {
            spriteRenderer.sprite = colckSprite;
        }
    }
}

public enum Notetype
{
    Apple,
    Blueberry,
    Clock
}
