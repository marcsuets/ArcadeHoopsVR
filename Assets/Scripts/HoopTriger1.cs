using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoopTriger1 : MonoBehaviour
{
    // Aquesta refer�ncia ser� al objecte fill
    private GameObject Trigger1;

    // Assignem el pare en l'inici (aquesta pot ser una refer�ncia a l'objecte pare manualment o autom�ticament)
    void Start()
    {
        // Obtenim el GameObject fill
        Trigger1 = transform.GetChild(0).gameObject;
    }

    // Funci� que es crida quan es detecta la col�lisi�
    void OnTriggerEnter(Collider colisio)
    {
        // Comprovem que l'objecte amb qu� ha col�lidit �s el que volem
        if (colisio.gameObject.CompareTag("Basketball")) // Afegeix la condici� que vulguis
        {
            // Ara cridem la funci� de l'objecte fill
            if (Trigger1 != null)
            {
                // Cridem una funci� del pare (suponem que tens una funci� "ExempleFuncio" al fill)
                Trigger1.GetComponent<HoopTriger2>().ActivarTrigger(colisio);
            }
        }
    }
}