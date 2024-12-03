using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameManager")]
public class GameManagerSO : ScriptableObject
{
    public event Action<float, float> OnActualizarStamina;
    public event Action OnPlayerCansado, OnPlayerRecuperado;
    public void ActualizarStamina(float staminaActual, float staminaMaxima)
    {
        OnActualizarStamina?.Invoke(staminaActual, staminaMaxima);
    }
    public void PlayerCansado()
    {
        OnPlayerCansado?.Invoke();
    }
    public void PlayerRecuperado()
    {
        OnPlayerRecuperado?.Invoke();
    }
}
