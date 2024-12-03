using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [SerializeField]
    private GameManagerSO gM;

    [SerializeField]
    private GameObject barraStamina;

    [SerializeField]
    private Image fill;

    private void OnEnable()
    {
        gM.OnActualizarStamina += ActualizarBarraStamina;
        gM.OnPlayerRecuperado += BarraRecuperada;
        gM.OnPlayerCansado += () => fill.color = Color.red;
    }


    private void ActualizarBarraStamina(float staminaActual, float staminaMaxima)
    {
        barraStamina.SetActive(true);
        fill.fillAmount = staminaActual / staminaMaxima;
    }
    private void BarraRecuperada()
    {
        fill.color = Color.green;
        barraStamina.SetActive(false);
    }

    private void OnDisable()
    {
        gM.OnActualizarStamina -= ActualizarBarraStamina;
        gM.OnPlayerRecuperado -= BarraRecuperada;
    }
}
