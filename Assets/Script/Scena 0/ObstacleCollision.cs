using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ObstacleCollision : MonoBehaviour
{
    //gestione sparizione punteggio se menù aperto
    public static bool MenuOpen = false;



    public GameObject oggettoDaAnimare;
    public GameObject oggettoDaAnimare30;
    public GameObject BossObject;
    [SerializeField] private AudioSource DistruzioneNavicellaConAsteroide;
    [SerializeField] private AudioSource AreUWinningSon;
    [SerializeField] private AudioSource EpicFight;
    [SerializeField] private AudioSource NormalFight;
    public static bool TypeOfFight = false;
    public GameObject explosionPrefab;
    private Scene currentScene;
    public static int vite = 3;
    private MeshCollider meshCollider;
    public float disableDuration = 2f;
    public GameObject SenderSand;
    public static bool DisattivaPerk = false;
    public Slider sliderToDeactivate;



    // Start is called before the first frame update
    void Start()
    {
       currentScene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (TypeOfFight==true)
        {
            NormalFight.Stop();
        }
       // print("Scena: "+ currentScene.name);


       
    }

    void OnCollisionEnter(Collision collision)
    {
        if (currentScene.name == "level_0")
{
    // Stampa un messaggio indicando che la navicella ha colpito qualcosa e specifica cosa ha colpito (il tag dell'oggetto di collisione).
    print("LA NAVICELLA HA colpito == Collisione!!! con: " + collision.gameObject.tag);

    // Se l'oggetto di collisione ha il tag "Steroid" (asteroide):
    if (collision.transform.tag == "Steroid")
    {
        // Crea un'istanza di "explosionPrefab" in posizione dell'oggetto di collisione con una scala specifica.
        Instantiate(explosionPrefab, transform.position, Quaternion.Euler(90f, 0f, 0f)).transform.localScale = new Vector3(2f, 2f, 2f);
        
        // Stampa un messaggio indicando che si è verificata una collisione con un asteroide.
        print("Questo è un asteroide");
        
        // Avvia un'animazione o suono (ad esempio, "DistruzioneNavicellaConAsteroide").
        DistruzioneNavicellaConAsteroide.Play();
        
        // Distrugge l'oggetto di collisione (l'asteroide).
        Destroy(collision.gameObject);
        
        // Disabilita il componente MeshRenderer dell'oggetto corrente (la navicella).
        this.GetComponent<MeshRenderer>().enabled = false;
        
        // Resetta il valore di "MaxStereoid" a 0.
        ArrayScript.MaxStereoid = 0;
        
        // Avvia una coroutine per ricaricare la scena dopo un ritardo di 1.5 secondi.
        StartCoroutine(ReloadSceneAfterDelay(1.5f));
    }
    // Se l'oggetto di collisione ha il tag "End":
    else if (collision.transform.tag == "End")
    {
        // Stampa un messaggio indicando che è stato raggiunto il punto finale.
        print("FINE");
        
        // Attiva un'animazione sull'oggetto "oggettoDaAnimare".
        oggettoDaAnimare.transform.GetComponent<Animator>().SetTrigger("Activated");
        
        // Imposta una variabile (forse usata per il menu) su "true".
        MenuOpen = true;
        
        // Riproduce un suono (ad esempio, "AreUWinningSon").
        AreUWinningSon.Play();
        
        // Ferma il tempo di gioco (pausa il gioco).
        Time.timeScale = 0;
    }
}


        if (currentScene.name == "level_30")
        {


            if (collision.transform.tag == "Steroid")
            {
                Instantiate(explosionPrefab, transform.position, Quaternion.Euler(90f, 0f, 0f)).transform.localScale = new Vector3(2f, 2f, 2f);
                print("Quest è un asteroide");
                DistruzioneNavicellaConAsteroide.Play();
                //Destroy(collision.gameObject);
                //this.GetComponent<MeshRenderer>().enabled = false;
                //StartCoroutine(ReloadSceneAfterDelay(1.5f));
                vite--;
                
                
                meshCollider = GetComponent<MeshCollider>();
                
                meshCollider.enabled = false;

                // Avvia la coroutine per riattivare il MeshCollider dopo il tempo specificato
                StartCoroutine(Invicibletime(disableDuration));




                print("Numero vite: " + vite);
                if (collision.transform.tag == "Steroid" && vite == 0)
                {
                    // Disabilita il componente MeshRenderer dell'oggetto corrente, rendendo l'oggetto invisibile.
                    this.GetComponent<MeshRenderer>().enabled = false;

                    // Avvia una coroutine per ricaricare la scena dopo un ritardo di 1.5 secondi, in modo che il gioco venga resettato.
                    StartCoroutine(ReloadSceneAfterDelay(1.5f));

                    // Distrugge l'oggetto di collisione (l'oggetto specifico con cui si è verificata la collisione).
                    Destroy(collision.gameObject);

                    // Imposta la variabile "perk" dell'oggetto BulletShootShip su "false".
                    BulletShootShip.perk = false;

                    // Imposta la variabile "DisattivaPerk" su "false".
                    DisattivaPerk = false;

                    // Imposta la variabile "firstState" dell'oggetto BulletShootShip su "true".
                    BulletShootShip.firstState = true;
                }



            }
            if (collision.transform.tag == "Perk")
            {

                print("Hit con perk");
                Destroy(collision.gameObject);
                BulletShootShip.perk = true;
                DisattivaPerk = true;

            }
            else if (collision.transform.tag == "End")
            {

                oggettoDaAnimare.transform.GetComponent<Animator>().SetTrigger("Activated");
                MenuOpen = true;
                AreUWinningSon.Play();
                Time.timeScale = 0;

            }


            // Se l'oggetto di collisione ha il tag "BossFight":
            else if (collision.transform.tag == "BossFight")
            {
                // Ignora la collisione tra l'oggetto corrente e l'oggetto di collisione (forse per consentire al giocatore di passare attraverso il boss).
                Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());

                // Attiva l'oggetto "BossObject" nel gioco.
                BossObject.SetActive(true);

                // Abilita il componente SpriteRenderer dell'oggetto "BossObject" per renderlo visibile.
                BossObject.GetComponent<SpriteRenderer>().enabled = true;

                // Abilita il componente MeshCollider dell'oggetto "BossObject".
                BossObject.GetComponent<MeshCollider>().enabled = true;

                // Abilita il componente BoxCollider dell'oggetto "BossObject".
                BossObject.GetComponent<BoxCollider>().enabled = true;

                // Avvia un'animazione sull'oggetto "BossObject" con il trigger "StartAnimation".
                BossObject.transform.GetComponent<Animator>().SetTrigger("StartAnimation");

                // Riproduce un suono o effetto audio ("EpicFight").
                EpicFight.Play();

                // Imposta la variabile "TypeOfFight" su "true".
                TypeOfFight = true;

                // Riproduce di nuovo il suono "EpicFight".
                EpicFight.Play();

                // Disattiva l'oggetto "SenderSand".
                SenderSand.SetActive(false);

                // Disabilita "sliderToDeactivate" nel gioco.
                sliderToDeactivate.gameObject.SetActive(false);
            }

            // Se l'oggetto di collisione ha il tag "CBoss" e il numero di vite (vite) non è uguale a 0:
            else if (collision.transform.tag == "CBoss" && vite != 0)
            {
                // Crea un'istanza di "explosionPrefab" in posizione dell'oggetto corrente con una scala specifica.
                Instantiate(explosionPrefab, transform.position, Quaternion.Euler(90f, 0f, 0f)).transform.localScale = new Vector3(2f, 2f, 2f);

                // Riproduce un suono o effetto audio (ad esempio, "DistruzioneNavicellaConAsteroide").
                DistruzioneNavicellaConAsteroide.Play();

                // Decrementa il contatore di vite.
                vite--;

                // Disabilita il componente MeshCollider dell'oggetto corrente.
                meshCollider = GetComponent<MeshCollider>();
                meshCollider.enabled = false;

                // Avvia una coroutine per rendere l'oggetto invulnerabile per un periodo specificato.
                StartCoroutine(Invicibletime(disableDuration));
            }
            // Altrimenti, se l'oggetto di collisione ha il tag "CBoss" e il numero di vite (vite) è uguale a 0:
            else if (collision.transform.tag == "CBoss" && vite == 0)
            {
                // Crea un'istanza di "explosionPrefab" in posizione dell'oggetto corrente con una scala specifica.
                Instantiate(explosionPrefab, transform.position, Quaternion.Euler(90f, 0f, 0f)).transform.localScale = new Vector3(2f, 2f, 2f);

                // Riproduce un suono o effetto audio ("DistruzioneNavicellaConAsteroide").
                DistruzioneNavicellaConAsteroide.Play();

                // Disabilita il componente MeshCollider dell'oggetto corrente.
                meshCollider = GetComponent<MeshCollider>();
                meshCollider.enabled = false;

                // Avvia una coroutine per rendere l'oggetto invulnerabile per un periodo specificato.
                StartCoroutine(Invicibletime(disableDuration));

                // Disabilita il componente MeshRenderer dell'oggetto corrente, rendendo l'oggetto invisibile.
                this.GetComponent<MeshRenderer>().enabled = false;

                // Avvia una coroutine per ricaricare la scena dopo un ritardo di 1.5 secondi.
                StartCoroutine(ReloadSceneAfterDelay(1.5f));

                // Distrugge l'oggetto di collisione (l'oggetto specifico con cui si è verificata la collisione).
                Destroy(collision.gameObject);
            }

        }

    }
    IEnumerator Invicibletime(float delay)
    {
        // Attendi per il tempo specificato
        yield return new WaitForSeconds(delay);

        // Riattiva il MeshCollider
        meshCollider.enabled = true;
    }
    IEnumerator ReloadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        BulletShoot.counter = 0;
        

        if (currentScene.name == "level_30")
        {
            oggettoDaAnimare30.transform.GetComponent<Animator>().SetTrigger("Activated");
            Time.timeScale = 0; 
            vite = 3;
        }
        if (currentScene.name == "level_0")
        { SceneManager.LoadScene("level_0");
            ArrayScript.MaxStereoid = 0;
        }
        

        
    }





}
