using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraSpeed : MonoBehaviour
{


    public float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = 0;
        //float verticalMovement = verticalInput+ 1* speed * Time.deltaTime;
        transform.Translate(Vector3.back * speed * Time.deltaTime);
        //speed = speed + Time.deltaTime;
        //transform.Translate(0, verticalMovement, 0);





    }
}
