using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    
    public TextMeshProUGUI screenText;
    
    private AudioManager audioManager;
    private GameManager gameManager;
    private float time;
    int cont = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        audioManager = AudioManager.Instance;
        gameManager = GameManager.Instance;
        time = 120;
        ChangeTimeButton();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeTimeButton()
    {
        audioManager.PlayBasket();
        ManageTimeLevel();
        
        screenText.text = time + "\nSECONDS";
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
    }
}

    
