using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerScreen : MonoBehaviour
{
    
    private GameManager gm;
    private TextMeshProUGUI timerText;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.Instance;
        timerText = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.getGameOn())
        {
            timerText.text = gm.getTimeLeft().ToString("F1");
        }
        else
        {
            timerText.text = "0.0 S.";
        }
        
    }
}
