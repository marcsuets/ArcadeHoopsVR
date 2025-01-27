using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    
    public TextMeshProUGUI screenText;
    public TextMeshProUGUI blueButtonText;
    public TextMeshProUGUI redButtonText;
    
    private AudioManager audioManager;
    private GameManager gameManager;
    private float time;
    int cont = 1;
    
    void Start()
    {
        audioManager = AudioManager.Instance;
        gameManager = GameManager.Instance;
        time = 30;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.getGameOn())
        {
            screenText.text = "GO!";
            blueButtonText.text = "RESTART";
            redButtonText.text = "  STOP";
        }
        else
        {
            screenText.text = time + "\nSECONDS";
            blueButtonText.text = "CHANGE TIME";
            redButtonText.text = "START GAME";
        }
    }

    public void BlueButtonClicked()
    {
        audioManager.PlayButton();
        gameManager.ShowHighScoreScreen(false);
        if (gameManager.getGameOn())
        {
            Debug.Log("Restart game");
            gameManager.resetGame();
        }
        else
        {
            Debug.Log("Temps canviat");
            ManageTimeLevel();
            screenText.text = time + "\nSECONDS";
        }
    }

    public void RedButtonClicked()
    {
        audioManager.PlayButton();
        gameManager.ShowHighScoreScreen(false);
        if (gameManager.getGameOn())
        {
            // Stop game
            Debug.Log("Joc parat");
            gameManager.resetTimer();
            gameManager.setGameOn(false);
        }
        else
        {
            // Start Game
            Debug.Log("Joc iniciat");
            //gameManager.setGameOn(true);
            gameManager.resetGame();
        }
    }

    private void ManageTimeLevel()
    {
        switch (cont)
        {
            case 0:
                time = 30;
                cont++;
                break;
            case 1:
                time = 60;
                cont++;
                break;
            case 2:
                time = 120;
                cont++;
                break;
            case 3:
                time = 180;
                cont = 0;
                break;
            default:
                time = 30;
                break;
        }
        gameManager.setTimer(time);
    }
}