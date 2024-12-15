using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public static ScoreController Instance;
    [SerializeField] int score;
    [SerializeField] TMP_Text scoreText;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void AddToScore(int value)
    {
        score += value;
        scoreText.text = score.ToString();
    }
}
