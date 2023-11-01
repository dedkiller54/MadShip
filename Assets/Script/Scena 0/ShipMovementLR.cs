using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovementLR : MonoBehaviour
{
    public Rigidbody rb;
    public float forceAmount = 10;
    private Vector3 RightVector = new Vector3(-2f, 0f, 0f);
    private Vector3 LeftVector = new Vector3(2f, 0f, 0f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            /*
            
            rb.AddForce(Vector3.forward * forceAmount, ForceMode.Impulse);
            */
           // print("Right Premuto GoggyInfame");
            this.transform.GetComponent<Rigidbody>().AddForce(RightVector, ForceMode.Impulse);
            this.transform.GetComponent<Animator>().SetTrigger("Right");



    }
            
        /*
        else
        {
            this.transform.GetComponent<Animator>().SetTrigger("Right");
        }
        */

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            /*
            
            rb.AddForce(Vector3.forward * forceAmount, ForceMode.Impulse);
            */
           
            this.transform.GetComponent<Rigidbody>().AddForce(LeftVector, ForceMode.Impulse);
            this.transform.GetComponent<Animator>().SetTrigger("Left");
        }
        /*
        else
        {
            this.transform.GetComponent<Animator>().SetTrigger("Left");
        }
        */

    }
}
