using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private AudioManager audioManager;
    
    public static GameManager Instance { get; private set; }
    
    // Game on settings
    private bool gameOn = false;
    
    // Score settings
    private int score = 0;
    public double multiplier = 1;
    public int pointsPerBasket = 100;
    private int highScore = 0;
    public GameObject canvasHighscore;
    
    // Timer settings
    private float timer = 30;
    private float timeLeft;
    private bool timerIsRunning = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Makes the GameManager persist across scenes
        }
        else
        {
            Destroy(gameObject); // Ensures only one instance exists
        }
        
    }

    private void Start()
    {
        audioManager = AudioManager.Instance;
        timeLeft = timer;
        timerIsRunning = false;
        canvasHighscore.SetActive(false);
    }

    private void Update()   
    {
        if (gameOn)
        {
            timerIsRunning = true;
        }
        
        if (timerIsRunning)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
            }
            else
            {
                timeLeft = 0;
                timerIsRunning = false;
                gameOn = false;
                audioManager.PlayTimerFinished();

                RecalculateHighScore();
                
            }
        }
    }

    public void incrementScore()
    {
        score = (int)(score + (pointsPerBasket * multiplier));
    }

    public void resetScore()
    {
        score = 0;
    }

    public int getScore()
    {
        return score;
    }

    public int getHighScore()
    {
        return highScore;
    }

    /*public double getMultiplier()
    {
        return multiplier;
    }

    public void increaseMultiplier()
    {
        multiplier = multiplier + 0.2;
    }

    public void resetMultiplier()
    {
        multiplier = 1;
    }*/

    public void setTimer(float time)
    {
        timer = time;
        timeLeft = time;
    }

    public float GetTimer()
    {
        return timer;
    }

    public float getTimeLeft()
    {
        return timeLeft;
    }

    public void resetTimer()
    {
        timerIsRunning = false;
        timeLeft = timer;
    }

    public void setGameOn(bool isGameOn)
    {
        if (isGameOn)
        {
            resetScore();
        }
        this.gameOn = isGameOn;
    }

    public bool getGameOn()
    {
        return gameOn;
    }

    public void resetGame()
    {
        gameOn = false;
        resetScore();
        resetTimer();
        gameOn = true;
    }

    public void RecalculateHighScore()
    {
        switch (timer)
        {
            case 30:
                if (score > PlayerPrefs.GetInt("bestScore30s", 0))
                {
                    ShowHighScoreScreen(true);
                    Invoke("HideHighScoreScreen", 10f);
                    PlayerPrefs.SetInt("bestScore30s", score);
                    audioManager.PlayNewHighscore();
                }
                break;
                    
            case 60:
                if (score > PlayerPrefs.GetInt("bestScore60s", 0))
                {
                    ShowHighScoreScreen(true);
                    Invoke("HideHighScoreScreen", 10f);
                    PlayerPrefs.SetInt("bestScore60s", score);
                    audioManager.PlayNewHighscore();
                }
                break;
                    
            case 120:
                if (score > PlayerPrefs.GetInt("bestScore120s", 0))
                {
                    ShowHighScoreScreen(true);
                    Invoke("HideHighScoreScreen", 10f);
                    PlayerPrefs.SetInt("bestScore120s", score);
                    audioManager.PlayNewHighscore();
                }
                break;
                    
            case 180:
                if (score > PlayerPrefs.GetInt("bestScore180s", 0))
                {
                    ShowHighScoreScreen(true);
                    Invoke("HideHighScoreScreen", 10f);
                    PlayerPrefs.SetInt("bestScore180s", score);
                    audioManager.PlayNewHighscore();
                }
                break;
        }
    }

    public void ResetAllHighscores()
    {
        PlayerPrefs.SetInt("bestScore30s", 0);
        PlayerPrefs.SetInt("bestScore60s", 0);
        PlayerPrefs.SetInt("bestScore120s", 0);
        PlayerPrefs.SetInt("bestScore180s", 0);
        audioManager.PlayNewHighscore();
    }

    public void ShowHighScoreScreen(bool show)
    {
        canvasHighscore.SetActive(show);
    }

    public void HideHighScoreScreen()
    {
        canvasHighscore.SetActive(false);
    }
}