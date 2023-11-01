using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroyer : MonoBehaviour
{
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
        print("IL MURO DISTRUTTORE DI STEROIDI HA HITTATO con: " + collision.gameObject.tag);
        print("IL DISTRUTTORRE HA DISTRUTTO: "+ collision.gameObject.tag);

        if (collision.transform.tag == "Steroid")
        {

            Destroy(collision.gameObject);
        }
        if (collision.transform.tag == "Bullet")
        {

            Destroy(collision.gameObject);
        }
        if (collision.transform.tag == "CBoss")
        {

            Destroy(collision.gameObject);
        }
    }
}
