using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovementLR : MonoBehaviour
{
    public Rigidbody rb;
    public float forceAmount = 10;
    private Vector3 RightVector = new Vector3(-2f, 0f, 0f);
    private Vector3 LeftVector = new Vector3(2f, 0f, 0f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        // Questo blocco di codice controlla se il tasto della freccia destra (RightArrow) è premuto dall'utente.
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // Se il tasto della freccia destra è premuto:
            // - Viene aggiunto un impulso (forza) all'oggetto che contiene questo script nella direzione "RightVector" utilizzando ForceMode.Impulse.
            this.transform.GetComponent<Rigidbody>().AddForce(RightVector, ForceMode.Impulse);

            // - Viene attivata una specifica animazione chiamata "Right" tramite il componente Animator associato all'oggetto.
            this.transform.GetComponent<Animator>().SetTrigger("Right");
        }

        /*
        else
        {
            this.transform.GetComponent<Animator>().SetTrigger("Right");
        }
        */

        // Questo blocco di codice verifica se il tasto della freccia sinistra (LeftArrow) è premuto dall'utente.
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // Se il tasto della freccia sinistra è premuto:
            // - Viene aggiunto un impulso (forza) all'oggetto che contiene questo script nella direzione "LeftVector" utilizzando ForceMode.Impulse.
            this.transform.GetComponent<Rigidbody>().AddForce(LeftVector, ForceMode.Impulse);

            // - Viene attivata una specifica animazione chiamata "Left" tramite il componente Animator associato all'oggetto.
            this.transform.GetComponent<Animator>().SetTrigger("Left");
        }

        /*
        else
        {
            this.transform.GetComponent<Animator>().SetTrigger("Left");
        }
        */

    }
}
