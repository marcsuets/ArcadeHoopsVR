using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private AudioManager audioManager;
    
    public static GameManager Instance { get; private set; }
    
    private int score = 0;
    public double multiplier = 1;
    public int pointsPerBasket = 100;
    
    public float timer = 10;
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
        timerIsRunning = true;
    }

    private void Update()   
    {
        
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
                TimerEnded();
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

    public double getMultiplier()
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
    }
    
    void TimerEnded()
    {
        audioManager.PlayTimerFinished();
    }
}