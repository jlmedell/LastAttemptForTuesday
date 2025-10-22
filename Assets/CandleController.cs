using UnityEngine;
using System.Collections;

public class CandleController : MonoBehaviour
{
    public Sprite litSprite;
    public Sprite burntOutSprite;
    public float fadeDuration = 1f;

    private SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void SetBurntOut(bool isBurntOut)
    {
        if (sr == null) return;
        sr.sprite = isBurntOut ? burntOutSprite : litSprite;
    }

    public IEnumerator BurnOutEffect()
    {
        if (sr == null) yield break;

        // Switch to burnt-out sprite but start transparent
        sr.sprite = burntOutSprite;
        Color c = sr.color;
        c.a = 0f;
        sr.color = c;

        float elapsed = 0f;
        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            c.a = Mathf.Lerp(0f, 1f, elapsed / fadeDuration);
            sr.color = c;
            yield return null;
        }

        sr.color = Color.white;
    }
}
