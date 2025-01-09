using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;

public class HoopTriger2 : MonoBehaviour
    
{
    private Collision Ball;
    private bool Activat = false;
    private int Score = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivarTrigger(Collision colisio)
    {
        Ball = colisio;
        Activat = true;
    }

    void OnCollisionEnter(Collision colisio)
    {
        // Comprovem que l'objecte amb què ha col·lidit és el que volem
        if (colisio == Ball & Activat == true)
        {
            Score++;
            Debug.Log("Punt");
            Activat = false;
        }
    }
}
