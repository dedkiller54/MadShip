using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ArrayScript30 : MonoBehaviour
{

    
    public GameObject[] asteroidsArray;
    public Transform CameraPosition;
    private float timer;
        public float border;
    private GameObject AsteroideTemporaneo;
    private float spawnAsteroidInterval;
    public static int MaxStereoid30 = 0; 
    // Start is called before the first frame update
    void Start()
    {
        spawnAsteroidInterval = 0.5f;
        
        timer = spawnAsteroidInterval;
    }

    // Update is called once per frame
    void Update()
    {
        // Questo blocco di codice verifica se il timer è maggiore di zero.
        if (timer > 0)
        {
            // Se il timer è maggiore di zero, diminuisce il suo valore sottraendo il tempo trascorso da Time.deltaTime.
            timer -= Time.deltaTime;
        }
        else
        {
            // Se il timer è scaduto (ossia è diventato zero o inferiore), verifica se il numero massimo di asteroidi è inferiore a 200.
            if (MaxStereoid30 < 200)
            {
                // Se il numero massimo di asteroidi è inferiore a 200, reimposta il timer al valore di "spawnAsteroidInterval",
                // quindi chiama la funzione "SpawnAsteroid" per generare un asteroide e incrementa il contatore "MaxStereoid30".
                timer = spawnAsteroidInterval;
                SpawnAsteroid();
                MaxStereoid30++;
                // Stampa il numero di asteroidi spawnati a fini di debug.
                print("Steroidi spawnati: " + MaxStereoid30);
            }
        }




    }
    private void SpawnAsteroid()
    {

        // Genera una posizione casuale lungo l'asse X all'interno di un intervallo specificato (-border a border),
        // con l'asse Y a 0 e l'asse Z impostato a una posizione specifica (CameraPosition.position.z - 70).

        var position = new Vector3(Random.Range(-border, border), 0, CameraPosition.position.z + -70);

        // Seleziona casualmente un asteroide dall'array "asteroidsArray" utilizzando un indice casuale compreso tra 0 e la lunghezza dell'array - 1.
        var asteroid = asteroidsArray[Random.Range(0, asteroidsArray.Length - 1)];

        // Posiziona l'oggetto "asteroid" nella posizione calcolata in precedenza.
        asteroid.transform.position = position;


        // Imposta la scala dell'oggetto "asteroid" su un fattore di scala uniforme 
        //(2 volte la dimensione originale).
        asteroid.transform.localScale = Vector3.one * 2f;


        /*
        // Imposta la rotazione dell'oggetto "asteroid" su un'angolazione casuale lungo l'asse Y (yaw) 
        // utilizzando la funzione Quaternion.Euler. L'asteroide sarà in grado di ruotare casualmente intorno all'asse verticale.
        asteroid.transform.rotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);
        */

        /*
        // Aggiunge una forza di torsione all'asteroide utilizzando un Rigidbody associato all'oggetto.
        // La forza di torsione è applicata lungo i tre assi (X, Y e Z) con valori costanti 5, 5, 5. 
        GetComponent<Rigidbody>().AddTorque(5, 5, 5);
        */

        /*
        // Ruota l'oggetto "asteroid" utilizzando la funzione Rotate. L'asteroide ruota intorno all'asse verticale (Y)
        // con un'angolazione casuale moltiplicata per 100f. 
        // asteroid.transform.Rotate(Vector3.down, Random.Range(0f, 360f) * 100f );
        */

        // Ottiene il componente Rigidbody dall'oggetto "asteroid" e lo assegna a una variabile
        // chiamata "asteroidRigidbody".
        Rigidbody asteroidRigidbody = asteroid.GetComponent<Rigidbody>();


        // Crea una copia temporanea dell'oggetto "asteroid" utilizzando la
        // funzione Instantiate e assegna l'istanza a "AsteroideTemporaneo".
        AsteroideTemporaneo = Instantiate(asteroid);

        
        

       

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BossFight"))
        {
            Destroy(gameObject);
        }
    }
}

