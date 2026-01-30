using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [Header("UI References")]
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI scoreText;
    public GameObject winPanel;
    public TextMeshProUGUI winText;

    [Header("Game Settings")]
    public float gameTime = 15f;
    public int totalClickables = 5;
    public string nextSceneName = "NextLevel";

    private float currentTime;
    private int clickedCount = 0;
    private bool gameActive = true;

    void Start()
    {
        currentTime = gameTime;
        UpdateUI();

        if (winPanel != null)
            winPanel.SetActive(false);
    }

    void Update()
    {
        if (!gameActive) return;

        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            currentTime = 0;
            GameOver();
        }

        UpdateUI();
    }

    public void ObjectClicked()
    {
        if (!gameActive) return;

        clickedCount++;
        UpdateUI();

        if (clickedCount >= totalClickables)
        {
            WinGame();
        }
    }

    void UpdateUI()
    {
        if (timerText != null)
            timerText.text = "Time: " + Mathf.Ceil(currentTime).ToString() + "s";

        if (scoreText != null)
            scoreText.text = "Collected: " + clickedCount + "/" + totalClickables;
    }

    void WinGame()
    {
        gameActive = false;

        if (winPanel != null)
        {
            winPanel.SetActive(true);
            if (winText != null)
                winText.text = "You Win!\nTime Left: " + Mathf.Ceil(currentTime) + "s";
        }

        StartCoroutine(LoadNextScene());
    }

    void GameOver()
    {
        gameActive = false;

        if (winPanel != null)
        {
            winPanel.SetActive(true);
            if (winText != null)
                winText.text = "Time's Up!\nTry Again!";
        }

        StartCoroutine(RestartGame());
    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(nextSceneName);
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}