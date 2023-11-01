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
            print("LA NAVICELLA HA HITTATO == Collisione!!! con: " + collision.gameObject.tag);

            if (collision.transform.tag == "Steroid")
            {
                Instantiate(explosionPrefab, transform.position, Quaternion.Euler(90f, 0f, 0f)).transform.localScale = new Vector3(2f, 2f, 2f);
                print("Quest è un asteroide");
                DistruzioneNavicellaConAsteroide.Play();
                Destroy(collision.gameObject);
                this.GetComponent<MeshRenderer>().enabled = false;
                ArrayScript.MaxStereoid = 0;
                StartCoroutine(ReloadSceneAfterDelay(1.5f));





            }
            else if (collision.transform.tag == "End")
            {
                print("FINE");
                oggettoDaAnimare.transform.GetComponent<Animator>().SetTrigger("Activated");
                MenuOpen = true;
                AreUWinningSon.Play();
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
                //print("SUS");
                
                meshCollider = GetComponent<MeshCollider>();
                
                meshCollider.enabled = false;

                // Avvia la coroutine per riattivare il MeshCollider dopo il tempo specificato
                StartCoroutine(Invicibletime(disableDuration));




                print("Numero vite: " + vite);
                if (collision.transform.tag == "Steroid" && vite == 0)
                {
                    this.GetComponent<MeshRenderer>().enabled = false;
                    StartCoroutine(ReloadSceneAfterDelay(1.5f));
                    Destroy(collision.gameObject);
                    BulletShootShip.perk = false;
                    DisattivaPerk = false;
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
            else if (collision.transform.tag == "BossFight")
            {
                Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
                BossObject.SetActive(true);
                BossObject.GetComponent<SpriteRenderer>().enabled = true;
                BossObject.GetComponent<MeshCollider>().enabled = true;
                BossObject.GetComponent<BoxCollider>().enabled = true;
                BossObject.transform.GetComponent<Animator>().SetTrigger("StartAnimation");
                EpicFight.Play();
                TypeOfFight = true;
                EpicFight.Play();
                SenderSand.SetActive(false);
                sliderToDeactivate.gameObject.SetActive(false);


            }

            else if (collision.transform.tag == "CBoss" && vite != 0)
            {
                Instantiate(explosionPrefab, transform.position, Quaternion.Euler(90f, 0f, 0f)).transform.localScale = new Vector3(2f, 2f, 2f);
                DistruzioneNavicellaConAsteroide.Play();
                vite--;
                meshCollider = GetComponent<MeshCollider>();
                meshCollider.enabled = false;
                StartCoroutine(Invicibletime(disableDuration));
            }
            else if (collision.transform.tag == "CBoss" && vite == 0) 
            {
                Instantiate(explosionPrefab, transform.position, Quaternion.Euler(90f, 0f, 0f)).transform.localScale = new Vector3(2f, 2f, 2f);
                DistruzioneNavicellaConAsteroide.Play();
                meshCollider = GetComponent<MeshCollider>();
                meshCollider.enabled = false;
                StartCoroutine(Invicibletime(disableDuration));
                this.GetComponent<MeshRenderer>().enabled = false;
                StartCoroutine(ReloadSceneAfterDelay(1.5f));
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
