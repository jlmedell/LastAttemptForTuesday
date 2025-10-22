using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitController : MonoBehaviour
{
    public string carTag = "Car"; // tag of your car object
    public Vector2 minBounds = new Vector2(-8f, -4f); // bottom-left of screen
    public Vector2 maxBounds = new Vector2(8f, 4f);   // top-right of screen

    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.enabled = false; // keep exit invisible initially

        // Move to a random position on start
        RandomizePosition();
    }

    // Call this if you also use CandleLight trigger for visibility
    public void ShowExit()
    {
        sr.enabled = true;
    }

    public void HideExit()
    {
        sr.enabled = false;
    }

    void RandomizePosition()
    {
        float randomX = Random.Range(minBounds.x, maxBounds.x);
        float randomY = Random.Range(minBounds.y, maxBounds.y);
        transform.position = new Vector3(randomX, randomY, transform.position.z);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // If car touches exit, restart scene
        if (other.CompareTag(carTag))
        {
            GameManager.Instance.AddScore(1);
            // Reload current scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
