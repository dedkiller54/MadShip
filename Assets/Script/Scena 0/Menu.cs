using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public TextMeshProUGUI _Perfect_Level;
    // Start is called before the first frame update
    void Start()
    {
        _Perfect_Level.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("m"))
        {

            this.transform.GetComponent<Animator>().SetTrigger("Activated");
            Time.timeScale = 0;

        }
        if (BulletShoot.perfect == true)
        {
            
            _Perfect_Level.enabled = true;
        }








    }
}
