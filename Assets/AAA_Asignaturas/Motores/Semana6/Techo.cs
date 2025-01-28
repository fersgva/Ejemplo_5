using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Techo : MonoBehaviour
{
    [SerializeField]
    private Motores.GameManagerSO gM;


    [SerializeField]
    private int id;

    private float yDirection = 1;
    private bool activar;

    private void OnEnable()
    {
        gM.OnNuevaInteraccion += Activar;
    }

    private void Activar(int id)
    {
        if(this.id == id)
        {
            activar = true;
            //Invertimos el estado
            yDirection *= -1f;
        }
    }

    // Update is called once per frame
    void Update()
    {   
        if(activar)
        {
             transform.Translate(new Vector3(0, yDirection, 0) * 5 * Time.deltaTime, Space.World);
        }
    }

    private void OnDisable()
    {
        gM.OnNuevaInteraccion -= Activar;
    }
}
