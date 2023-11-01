using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeShooter : MonoBehaviour
{
    public GameObject target; // L'oggetto verso cui sparare
    public float shootForce = 5f; // Forza del lancio del cubo
    public float shootingInterval = 1f; // Intervallo di tempo tra gli spari
    public Material cubeMaterial; // Materiale del cubo sparato

    public float minX = -1274f; // Posizione minima sull'asse delle x
    public float maxX = 1258f; // Posizione massima sull'asse delle x

    private float timer; // Timer per gestire l'intervallo di sparo

    // Start is called before the first frame update
    void Start()
    {
        timer = shootingInterval;
    }

    // Update is called once per frame
    void Update()
    {
        // Aggiorna il timer
        timer -= Time.deltaTime;

        // Controlla se è passato l'intervallo di sparo
        if (timer <= 0f)
        {
            Shoot();
            timer = shootingInterval; // Resettare il timer all'intervallo di sparo
        }

        // Muovi il cubo sulla base dell'input dell'asse delle x
        float movement = Input.GetAxis("Horizontal");
        Vector3 newPosition = transform.position + new Vector3(movement, 0f, 0f) * Time.deltaTime * shootForce;
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        transform.position = newPosition;
    }

    void Shoot()
    {
        Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f).normalized;
        // Calcola la direzione dal cubo al target
        Vector3 direction = (target.transform.position - transform.position).normalized;
        direction.z = 0f; // Blocca il movimento lungo l'asse Z
       // direction.x = 0f;
       // direction.y = 0f;

        // Crea un cubo e lo posiziona alla posizione del cubo sparatore
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = transform.position;
        cube.transform.localScale = Vector3.one * 2;

        // Aggiunge un rigidbody al cubo
        Rigidbody cubeRigidbody = cube.AddComponent<Rigidbody>();

        // Imposta la velocità del cubo al prodotto della direzione per la forza di sparo
        cubeRigidbody.velocity = randomDirection * shootForce;
        cubeRigidbody.useGravity = false;

        // Imposta il colore del cubo
        Renderer cubeRenderer = cube.GetComponent<Renderer>();
        cubeRenderer.material = cubeMaterial;

        // Imposta il tag del cubo come "CBoss"
        cube.tag = "CBoss";
        cube.layer = LayerMask.NameToLayer("BossFight");

        // Allinea la rotazione del cubo verso il target
        cube.transform.LookAt(target.transform);
    }
}
