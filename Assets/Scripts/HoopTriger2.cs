using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;

public class HoopTriger2 : MonoBehaviour
{
    
    private GameManager gm;
    private AudioManager audioManager;
    
    private Collider Ball;
    private bool Activat = false;
    private int Score = 0;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.Instance;
        audioManager = AudioManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivarTrigger(Collider colisio)
    {
        Ball = colisio;
        Activat = true;
    }

    void OnTriggerEnter(Collider other)
    {
        // Comprovem que l'objecte amb què ha col·lidit és el que volem
        if (other == Ball && Activat == true)
        {
            gm.incrementScore();
            audioManager.PlayBasket();
            Activat = false;
        }
    }

}
