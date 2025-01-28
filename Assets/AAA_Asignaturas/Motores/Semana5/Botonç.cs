using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botonç : MonoBehaviour
{
    [SerializeField] private Motores.GameManagerSO gM;
    [SerializeField] private int idBoton;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.TryGetComponent(out PlayerDynamic player))
        {
            gM.InteractuableEjecutado(idBoton);
        }
    }
}
