using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static int highScore;

    #region Singleton

    private static ScoreManager _instance = null;
    public static ScoreManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ScoreManager>();

                if (_instance == null)
                {
                    Debug.LogError("Fatal Error: ScoreManager not Found");
                }
            }

            return _instance;
        }
    }

    #endregion

    public int tileRatio;
    public int comboRatio;

    public int HighScore
    {
        get
        {
            return highScore;
        }
    }

    public int CurrentScore
    {
        get
        {
            return currentScore;
        }
    }

    private int currentScore;

    void Start()
    {
        ResetCurrentScore();
    }

    void Update()
    {
        
    }

    public void ResetCurrentScore()
    {
        currentScore = 0;
    }

    public void IncrementCurrentScore(int tileCount, int comboCount)
    {
        currentScore += (tileCount * tileRatio) * (comboCount * comboRatio);

        SoundManager.Instance.PlayScore(comboCount > 1);
    }

    public void SetHighScore()
    {
        if (currentScore >= highScore)
        {
            highScore = currentScore;
        }
    }
}
