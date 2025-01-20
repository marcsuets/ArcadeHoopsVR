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
        else
        {
            score.text = "0 P.";
        }

        highscore.text = "HIGHSCORE : " + gm.getHighScore();

    }
}
