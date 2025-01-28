using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    [SerializeField]
    private Motores.GameManagerSO gM;


    [SerializeField]
    private Transform destination;

    [SerializeField]
    private float velocity;

    [SerializeField]
    private int id;

    private bool opening;



    public void Interactuar()
    {
        opening = true;
        gM.InteractuableEjecutado(id);
    }

    // Update is called once per frame
    void Update()
    {
        if(opening)
        {
            //CINEMÁTICA: Sin fisicas.
            transform.position = Vector3.MoveTowards(transform.position, destination.position, velocity * Time.deltaTime);
        }
    }
}
