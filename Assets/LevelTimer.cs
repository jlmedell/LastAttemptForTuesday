using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelTimer : MonoBehaviour
{
    public float timeLimit = 20f;       // seconds per round
    public TMP_Text timerText;              // assigned automatically
    public CandleController candle;     // reference to candle

    private float remainingTime;
    private bool timeUp = false;

    void OnEnable()
    {
        // Subscribe to scene load event so we can relink UI after reload
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void Start()
    {
        StartTimer();
    }

    void StartTimer()
    {
        remainingTime = timeLimit;
        timeUp = false;
        UpdateTimerDisplay();
    }

    void Update()
    {
        if (timeUp) return;

        remainingTime -= Time.deltaTime;

        if (remainingTime <= 0f)
        {
            remainingTime = 0f;
            StartCoroutine(TimeOutSequence());
        }

        UpdateTimerDisplay();
    }

    void UpdateTimerDisplay()
    {
        if (timerText != null)
        {
            timerText.text = "Time: " + Mathf.CeilToInt(remainingTime).ToString();
        }
    }

    IEnumerator TimeOutSequence()
    {
        timeUp = true;

        // Tell candle to switch to burnt-out appearance
        if (candle != null)
            yield return StartCoroutine(candle.BurnOutEffect());

        // Load GameOver scene
        SceneManager.LoadScene("GameOver");
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Re-find the TimerText UI in the new scene
        if (timerText == null)
            timerText = GameObject.Find("TimerText")?.GetComponent<TMP_Text>();

        // Re-find the candle in the new scene (optional safety)
        if (candle == null)
            candle = GameObject.FindObjectOfType<CandleController>();

        // Reset the timer
        StartTimer();
    }
}