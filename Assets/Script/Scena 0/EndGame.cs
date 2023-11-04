using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{


    public GameObject oggettoDaAnimare;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }





    void OnCollisionEnter(Collision collision)
    {   //questo print permette di capire con che cosa ho colpito
      //  print(" LA NAVICELLA HA Colpito == Collisione!!! con: " + collision.gameObject.tag);

        /*

        if (collision.transform.tag == "End")
        {
            //print("FINE");
            oggettoDaAnimare.transform.GetComponent<Animator>().SetTrigger("Activated");

        }
        */
    }
}
