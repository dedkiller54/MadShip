using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
    public float timeThreshold = 40f; // Tempo minimo per avviare l'animazione
    public float distanceThreshold = 10f; // Distanza minima per avviare l'animazione
    public Animator spaceshipAnimator; // Riferimento all'animator dell'astronave

    private float elapsedTime;
    private float initialPosition;

    private void Start()
    {
        elapsedTime = 0f;
        initialPosition = transform.position.x;
    }

    private void Update()
    {
        // Calcola la distanza percorsa dall'astronave
        float distanceTraveled = Mathf.Abs(transform.position.x - initialPosition);

        // Stampa la distanza percorsa
        //print("Distanza percorsa: " + distanceTraveled);

        // Se la distanza supera la soglia impostata, avvia l'animazione
        /*
        if (distanceTraveled >= distanceThreshold)
        {
            spaceshipAnimator.SetTrigger("StartAnimation");
            print("SAS");
        }
        */
        // Aggiorna il tempo trascorso
        elapsedTime += Time.deltaTime;

        // Stampa il tempo trascorso
        //print("Tempo trascorso: " + elapsedTime);

        // Se è trascorso il tempo minimo, ma non è stata avviata l'animazione, avviala
        /*
        if (elapsedTime >= timeThreshold && !spaceshipAnimator.GetCurrentAnimatorStateInfo(0).IsName("YourAnimationName"))
        {
            spaceshipAnimator.SetTrigger("StartAnimation");
            print("Ora avvio l'animazione");
        }
        */
    }
}

