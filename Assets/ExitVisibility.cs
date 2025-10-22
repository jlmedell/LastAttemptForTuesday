using UnityEngine;

public class ExitVisibility : MonoBehaviour
{
    public string candleLightTag = "CandleLight"; // we'll use this tag to identify the object
    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.enabled = false; // Exit starts invisible
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(candleLightTag))
        {
            sr.enabled = true; // Show when Candle Light touches
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(candleLightTag))
        {
            sr.enabled = false; // Hide when Candle Light leaves
        }
    }
}