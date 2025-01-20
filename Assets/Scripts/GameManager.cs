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
                highScore = 3030;
                
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
        this.timer = time;
    }

    public float getTimeLeft()
    {
        return timeLeft;
    }

    public void setTimerIsRunning(bool isTimerRunning)
    {
        this.timerIsRunning = isTimerRunning;
    }

    public void resetTimer()
    {
        timerIsRunning = false;
        timeLeft = timer;
    }

    public void setGameOn(bool isGameOn)
    {
        Debug.Log("Game On <<<<<<<<<<<<<<<<<<<<" + isGameOn);
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
    
}