using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletShoot : MonoBehaviour
{
    public static bool perfect = false;
    public static int counter = 0;
    public float moveSpeed;
    public GameObject explosionPrefab;
    private Scene currentScene;
    public AudioSource CHittaADestroyAsteroidEffect;
    public GameObject bulletRigidbody;
    public GameObject PerkIcon;
    int randomSpawnPerk;

    // Start is called before the first frame update
    void Start()
    {

        currentScene = SceneManager.GetActiveScene();
        // Distugge proiettili dopo 3 secondi
        // Destroy(this.gameObject, 3f);

        

    }

    // Update is called once per frame
    void Update()
    {
        // Gestione livello perfect
        if (counter >= 70)
        {
            perfect = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (currentScene.name == "level_0")
        {
            if (collision.transform.tag == "Steroid")
            {
                // Crea l'effetto di esplosione
                GameObject explosionEffect = Instantiate(explosionPrefab, transform.position, Quaternion.Euler(90f, 0f, 0f));
                explosionEffect.transform.localScale = new Vector3(2f, 2f, 2f);

                // Riproduci l'effetto sonoro di distruzione
                CHittaADestroyAsteroidEffect.Play();

                
                GetComponent<Collider>().enabled = false;
                GetComponent<MeshRenderer>().enabled = false;
                Destroy(collision.gameObject);
                StartCoroutine(DestroyAfterDelay(1f, explosionEffect));

                counter++;
                

            }

        }

        if (currentScene.name == "level_30")
        {
            if (collision.transform.tag == "Steroid")
            {
                // Crea l'effetto di esplosione
                // Crea un effetto di esplosione all'indirizzo dell'oggetto corrente e lo scala.
                GameObject explosionEffect = Instantiate(explosionPrefab, transform.position, Quaternion.Euler(90f, 0f, 0f));

                // Riproduce un effetto sonoro di distruzione (CHittaADestroyAsteroidEffect).
                explosionEffect.transform.localScale = new Vector3(2f, 2f, 2f);

                // Riproduci l'effetto sonoro di distruzione
                CHittaADestroyAsteroidEffect.Play();

                // Disabilita il componente Collider dell'oggetto corrente.
                GetComponent<Collider>().enabled = false;

                // Disabilita il componente MeshRenderer dell'oggetto corrente, rendendo l'oggetto invisibile.
                GetComponent<MeshRenderer>().enabled = false;

                // Distrugge l'oggetto di collisione (l'asteroide).
                Destroy(collision.gameObject);

                // Avvia una coroutine per distruggere l'effetto di esplosione dopo un ritardo di 1 secondo.
                StartCoroutine(DestroyAfterDelay(1f, explosionEffect));


                counter++;
                randomSpawnPerk = Random.RandomRange(1, 6);
                if (randomSpawnPerk >= 4 && ObstacleCollision.DisattivaPerk == false)
                {

                    print("SpawnPerk");

                    // Crea l'icona del perk all'indirizzo dell'oggetto corrente e la scala.
                    GameObject perkIcon = Instantiate(PerkIcon, transform.position, Quaternion.Euler(90f, 0f, 0f));
                    perkIcon.transform.localScale = new Vector3(2f, 2f, 2f);


                }



            }
            if (collision.transform.tag == "BossFight")
            {
                
                Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
                Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
                
                Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
                //Destroy(this.gameObject);
              // Rigidbody bulletRigidbody = GetComponent<Rigidbody>();
                //bulletRigidbody.isKinematic = true;
                print("Sonopiero");
                /*
                Rigidbody bulletRigidbody = GetComponent<Rigidbody>();
                if (bulletRigidbody != null)
                {
                    bulletRigidbody.velocity = bulletRigidbody.velocity.normalized * moveSpeed;
                    bulletRigidbody.isKinematic = true;
                }
                */

            }

            if (collision.transform.tag == "Boss")
            {
                // Distruggi il proiettile
                Destroy(this.gameObject);
            }

        }




        }

    IEnumerator DestroyAfterDelay(float delay, GameObject explosionEffect)
    {
        yield return new WaitForSeconds(delay);

        // Disabilita l'effetto di esplosione dopo un ritardo
        ParticleSystem explosionParticles = explosionEffect.GetComponent<ParticleSystem>();
        if (explosionParticles != null)
        {
            explosionParticles.Stop();
        }

        // Disattiva completamente l'oggetto di esplosione dopo un breve ritardo
        yield return new WaitForSeconds(0.5f);
        Destroy(explosionEffect);

        Destroy(this.gameObject);
    }
}

























    /*
    void OnCollisionEnter(Collision collision)
    {   //questo print permette di capire con che cosa ho colpito
        // print("IL COLPO HA Colpito == Collisione!!! con: " + collision.gameObject.tag);

        

        if (collision.transform.tag == "Steroid")
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.Euler(90f, 0f, 0f)).transform.localScale = new Vector3(2f, 2f, 2f); 
            CHittaADestroyAsteroidEffect.Play();
            
            // print("Il colpo ha Colpito l'asteroide");
            //ricarica la scena
            //SceneManager.LoadScene("SampleScene");
            //fare menu sconfittà
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            counter++;
            
            

        }
    }

    */


