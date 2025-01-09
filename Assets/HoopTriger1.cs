using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoopTriger1 : MonoBehaviour
{
    // Aquesta referència serà al objecte fill
    private GameObject Trigger1;

    // Assignem el pare en l'inici (aquesta pot ser una referència a l'objecte pare manualment o automàticament)
    void Start()
    {
        // Obtenim el GameObject fill
        Trigger1 = transform.GetChild(0).gameObject;
    }

    // Funció que es crida quan es detecta la col·lisió
    void OnCollisionEnter(Collision colisio)
    {
        // Comprovem que l'objecte amb què ha col·lidit és el que volem
        if (colisio.gameObject.CompareTag("BasketBall")) // Afegeix la condició que vulguis
        {
            // Ara cridem la funció de l'objecte fill
            if (Trigger1 != null)
            {
                // Cridem una funció del pare (suponem que tens una funció "ExempleFuncio" al fill)
                Trigger1.GetComponent<HoopTriger2>().ActivarTrigger(colisio);
            }
        }
    }
}