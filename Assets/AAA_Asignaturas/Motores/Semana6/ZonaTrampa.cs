using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaTrampa : MonoBehaviour
{
    [SerializeField]
    private Motores.GameManagerSO gM;

    [SerializeField]
    private int id;

    public void CambiarEstado()
    {
        gM.InteractuableEjecutado(id);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out PlayerDynamic player))
        {
            CambiarEstado();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerDynamic player))
        {
            CambiarEstado();
        }
    }
}
