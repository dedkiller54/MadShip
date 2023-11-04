using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //fa riferimento al bottone Restart
    public void RestartGame()
    {
        SceneManager.LoadScene("level_30");

        // Ripristina il tempo di gioco a 1.0f, consentendo al gioco di riprendere con la velocità normale.
        Time.timeScale = 1.0f;


        // Resetta la variabile "MaxStereoid30" dell'oggetto "ArrayScript30" a zero.
        ArrayScript30.MaxStereoid30 = 0;

    }
}
