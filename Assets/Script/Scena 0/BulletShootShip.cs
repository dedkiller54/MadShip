using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShootShip : MonoBehaviour
{
    [SerializeField] private AudioSource Sparoaltastodx;
    public GameObject projectilePrefab;
    private GameObject tempProjectile;
    private float lastFireTime;
    public float fireInterval = 100;
   public static bool perk = false;
    public static bool firstState = true;
    void Update()
    {
        print("Time: " + Time.timeScale);
        if (Input.GetButtonDown("Fire1") && Time.time - lastFireTime >= 0.3)
        {

            if(perk == true)
            {
                tempProjectile = Instantiate(projectilePrefab, transform.position + new Vector3(-2, 0, -5), Quaternion.Euler(90, 90, 90));
                tempProjectile.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -6000));
                tempProjectile = Instantiate(projectilePrefab, transform.position + new Vector3(2, 0, -5), Quaternion.Euler(90, 90, 90));
                tempProjectile.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -6000));
                firstState= false;
            }
           
            if (firstState == true)

            {
                tempProjectile = Instantiate(projectilePrefab, transform.position + new Vector3(0, 0, -5), Quaternion.Euler(90, 90, 90));
                tempProjectile.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -6000));
            }


            if (Time.timeScale != 0)
            {
               //print("SAS");
                Sparoaltastodx.Play();
            }
            
            lastFireTime = Time.time;
            //print("lastFireTime: " + lastFireTime);
           // print("Time.time:  " + Time.time);
           // print("fireInterval: " + fireInterval);
        }
    }
}
