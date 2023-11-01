using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArrayScript : MonoBehaviour
{


    //go tony prendi i sordi
    public GameObject[] asteroidsArray;
    public Transform CameraPosition;
    private float timer;
    public float border;
    private GameObject AsteroideTemporaneo;
    private float spawnAsteroidInterval;
    public static int MaxStereoid = 0;
    public static bool BossFightTime = false;
    private Scene currentScene;
    // Start is called before the first frame update
    void Start()
    {
        spawnAsteroidInterval = 0.5f;
        // timer = Random.Range(0.1f, 1f);
        timer = spawnAsteroidInterval;
        
        currentScene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {

        if (currentScene.name == "level_0")
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                if (MaxStereoid < 200 )
                {
                    // timer = Random.Range(0.1f, 1f);
                    timer = spawnAsteroidInterval;
                    SpawnAsteroid();
                    MaxStereoid++;
                    
                  //print("Steroidi spwanati:" + MaxStereoid);
                }
            }

        }
        if (currentScene.name == "level_30")
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                if (MaxStereoid < 70)
                {
                    // timer = Random.Range(0.1f, 1f);
                    timer = spawnAsteroidInterval;
                    SpawnAsteroid();
                    MaxStereoid++;
                    print("Steroidi spwanati:" + MaxStereoid);
                }
            }

        }
    }
        private void SpawnAsteroid()
        {
       //navetta.tranform.position.y > -103
                var position = new Vector3(Random.Range(-border, border), 0, CameraPosition.position.z + -70);
                var asteroid = asteroidsArray[Random.Range(0, asteroidsArray.Length - 1)];
                asteroid.transform.position = position;

                asteroid.transform.localScale = Vector3.one * 5;



                //boh
                //asteroid.transform.rotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);
                //GetComponent<Rigidbody>().AddTorque(5, 5, 5);
                //asteroid.transform.Rotate(Vector3.down, Random.Range(0f, 360f) * 100f );

                float rotationSpeed = 100f; // Velocità di rotazione desiderata
                asteroid.transform.Rotate(Vector3.up, Random.Range(0f, 360f) * rotationSpeed);

                // Aggiungi il codice per far girare su se stesso l'asteroide utilizzando una forza di tipo torque
                Rigidbody asteroidRigidbody = asteroid.GetComponent<Rigidbody>();

                //boh

                AsteroideTemporaneo = Instantiate(asteroid);


                AsteroideTemporaneo.transform.GetComponent<Rigidbody>().AddTorque(100f, 100f, 100f);

                AsteroideTemporaneo.transform.localScale = new Vector3(AsteroideTemporaneo.transform.localScale.x * 3f, AsteroideTemporaneo.transform.localScale.y * 3f, AsteroideTemporaneo.transform.localScale.z * 3f);
            
        }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "BossFight")
        {
            Destroy(gameObject);
        }
    }
} 

