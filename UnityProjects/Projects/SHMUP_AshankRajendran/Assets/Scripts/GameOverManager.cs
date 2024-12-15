using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] TMP_Text gameScoreText;
    [SerializeField] TMP_Text gameOverScoreText;
    [SerializeField] Canvas gameOverCanvas;
    private void Start()
    {
        gameOverScoreText.text = "Score: " + gameScoreText.text;
        Time.timeScale = 0;
    }

    public void ActivateWithDelay(float delay)
    {
        Debug.Log("Activating game over canvas in " + delay + " seconds.");
        Invoke(nameof(ActivateGameOverCanvas), delay);
    }

    private void ActivateGameOverCanvas()
    {
        gameOverCanvas.gameObject.SetActive(true);
    }

    public void Restart()
    {
        Debug.Log("Restart");
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
