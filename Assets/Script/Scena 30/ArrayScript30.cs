using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ArrayScript30 : MonoBehaviour
{

    //go tony prendi i sordi
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
        // timer = Random.Range(0.1f, 1f);
        timer = spawnAsteroidInterval;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >0) 
        {
            timer -= Time.deltaTime;        
        }
        else
        {
            if (MaxStereoid30 < 200 ) { 
            // timer = Random.Range(0.1f, 1f);
            timer = spawnAsteroidInterval;
            SpawnAsteroid();
            MaxStereoid30++;
                print("Steroidi spwanati:" + MaxStereoid30);
            }
        }
        



    }
    private void SpawnAsteroid()
    {
        var position = new Vector3(Random.Range(-border, border), 0, CameraPosition.position.z + -70);
        var asteroid = asteroidsArray[Random.Range(0, asteroidsArray.Length - 1)];
        asteroid.transform.position = position;
        
        asteroid.transform.localScale = Vector3.one * 2f;



        //boh
        //asteroid.transform.rotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);
        //GetComponent<Rigidbody>().AddTorque(5, 5, 5);
        //asteroid.transform.Rotate(Vector3.down, Random.Range(0f, 360f) * 100f );

        
        

     
        Rigidbody asteroidRigidbody = asteroid.GetComponent<Rigidbody>();

        //boh

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

