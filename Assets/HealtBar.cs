using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtBar : MonoBehaviour
{
    [SerializeField] private Slider slider;


    // Questo metodo consente di aggiornare la barra della salute.
    public void UpdateHealthbar(float currentValue, float maxValue)
    {
        // Imposta il valore della barra della salute (slider) in base al rapporto tra il valore corrente e il valore massimo.
        slider.value = currentValue / maxValue;
    }
}
