using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [HideInInspector]
    public int score = 0;

    public TMP_Text scoreText; // assign in Inspector

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // keep across scene reloads
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else if (Instance != this)
        {
            Destroy(gameObject); // remove duplicates
        }

        UpdateScoreUI();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Update ScoreText reference in the new scene
        if (scoreText == null)
            scoreText = GameObject.Find("ScoreText")?.GetComponent<TMP_Text>();

        UpdateScoreUI();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }

    public void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}