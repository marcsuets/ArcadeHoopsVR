using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    
    private GameManager gm;
    public TextMeshProUGUI score;
    public TextMeshProUGUI highscore;
    
    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.getGameOn())
        {
            score.text = gm.getScore().ToString();
        }
        
        switch (gm.GetTimer())
        {
            case 30:
                highscore.text = "30S HIGHSCORE: " + PlayerPrefs.GetInt("bestScore30s");
                break;
                    
            case 60:
                highscore.text = "60S HIGHSCORE: " + PlayerPrefs.GetInt("bestScore60s");
                break;
                    
            case 120:
                highscore.text = "120S HIGHSCORE: " + PlayerPrefs.GetInt("bestScore120s");
                break;
                    
            case 180:
                highscore.text = "180S HIGHSCORE: " + PlayerPrefs.GetInt("bestScore180s");
                break;
        }

    }
}
