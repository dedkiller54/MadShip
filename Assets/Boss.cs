using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public int vita = 80;
    public int max_vita = 80;
    public int damage;
    public GameObject Buss;
    [SerializeField] HealtBar healtBar;
    public GameObject explosionPrefab;
    public GameObject oggettoDaAnimare;
    [SerializeField] private AudioSource AreUWinningSon;
    public Canvas canvasObject;
    public GameObject BossObject;
    public Slider sliderToDeactivate;
    [SerializeField] private AudioSource DistruzioneNavicellaConAsteroide;
    // Start is called before the first frame update
    void Start()
    {
        healtBar = GetComponentInChildren<HealtBar>();
        Buss.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Bullet")
        {
            // Riduci la vita del boss di 3 punti
            vita -= 3;

            // Aggiorna la barra della vita del boss
            if (healtBar != null)
            {
                healtBar.UpdateHealthbar(vita, max_vita);
            }

            // Controlla se il boss è stato sconfitto
            if (vita <= 0)
            {
                // Esegui le azioni per la sconfitta del boss
                BossDefeated();
            }

            // Distruggi il proiettile
            Destroy(collision.gameObject);
        }
    }

    private void BossDefeated()
    {
        print("Sono morto");
        // Istanzia l'effetto di esplosione principale
        GameObject explosionEffect = Instantiate(explosionPrefab, transform.position, Quaternion.Euler(90f, 0f, 0f));
        explosionEffect.transform.localScale = new Vector3(2f, 2f, 2f);

        // Istanzia l'effetto di esplosione aggiuntivo a +50 unità lungo l'asse X
        Vector3 explosionPositionX = transform.position + new Vector3(100f, 0f, 0f);
        GameObject explosionEffectX = Instantiate(explosionPrefab, explosionPositionX, Quaternion.Euler(90f, 0f, 0f));
        explosionEffectX.transform.localScale = new Vector3(2f, 2f, 2f);

        // Istanzia l'effetto di esplosione aggiuntivo a +50 unità lungo l'asse Y
        Vector3 explosionPositionY = transform.position + new Vector3(0f, 100f, 0f);
        GameObject explosionEffectY = Instantiate(explosionPrefab, explosionPositionY, Quaternion.Euler(90f, 0f, 0f));
        explosionEffectY.transform.localScale = new Vector3(2f, 2f, 2f);

        Vector3 explosionPositionZ = transform.position + new Vector3(0f, 100f, 100f);
        GameObject explosionEffectZ = Instantiate(explosionPrefab, explosionPositionY, Quaternion.Euler(90f, 0f, 0f));
        explosionEffectY.transform.localScale = new Vector3(2f, 2f, 2f);

        // Imposta l'effetto di esplosione principale e gli effetti aggiuntivi in loop
        ParticleSystem explosionParticles = explosionEffect.GetComponent<ParticleSystem>();
        ParticleSystem explosionParticlesX = explosionEffectX.GetComponent<ParticleSystem>();
        ParticleSystem explosionParticlesY = explosionEffectY.GetComponent<ParticleSystem>();
        ParticleSystem explosionParticlesZ = explosionEffectY.GetComponent<ParticleSystem>();


        if (explosionParticles != null)
        {
            explosionParticles.loop = true;
            explosionParticles.Play();
        }

        if (explosionParticlesX != null)
        {
            explosionParticlesX.loop = true;
            explosionParticlesX.Play();
        }

        if (explosionParticlesY != null)
        {
            explosionParticlesY.loop = true;
            explosionParticlesY.Play();
        }

        if (explosionParticlesZ != null)
        {
            explosionParticlesZ.loop = true;
            explosionParticlesZ.Play();
        }

        DistruzioneNavicellaConAsteroide.Play();
        BossObject.transform.GetComponent<Animator>().SetTrigger("EndBattle");
        sliderToDeactivate.gameObject.SetActive(false);
        //SCENA VINCITA
        //ANIMAZIONE SCONFITTA


        float delay = 2f;
        Invoke("ActivateMenuAndAudio", delay);
    }

    private void ActivateMenuAndAudio()
    {
        canvasObject.enabled = false;
        oggettoDaAnimare.transform.GetComponent<Animator>().SetTrigger("Activated");
        ObstacleCollision.MenuOpen = true;
        AreUWinningSon.Play();
        Time.timeScale = 0;

    }


}
