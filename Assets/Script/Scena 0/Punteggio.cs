using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Punteggio : MonoBehaviour
{
    public TextMeshProUGUI _Punteggio;
    public TextMeshProUGUI _Vite;
    private Scene currentScene;


    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
    }


   

// Update is called once per frame
void Update()
    {

        

            if (ObstacleCollision.MenuOpen == true)
        {
            _Punteggio.enabled = false;
        }

        if (currentScene.name == "level_0")
        {
            _Punteggio.text = "Punteggio: " + BulletShoot.counter + "/  " + ArrayScript.MaxStereoid;
        }
        if (currentScene.name == "level_30")
        {

            _Punteggio.text = "Punteggio: " + BulletShoot.counter + "/  " + ArrayScript30.MaxStereoid30;


        }
            _Vite.text = "Vite: " + ObstacleCollision.vite;
    }
}
