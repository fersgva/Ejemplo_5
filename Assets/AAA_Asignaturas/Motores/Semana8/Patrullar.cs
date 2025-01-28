using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrullar : MonoBehaviour
{
    [SerializeField]
    private Transform ruta;

    [SerializeField]
    private float tiempoDeEspera;

    [SerializeField]
    private float rangoVision;

    [SerializeField]
    private float anguloVision;

    [SerializeField]
    private LayerMask queEsTarget;

    [SerializeField]
    private LayerMask queEsObstaculo;

    private List<Vector3> puntosDeRuta = new List<Vector3>();
    private NavMeshAgent agent;
    private int indicePuntoActual = 0; //Marca el índice de la lista
    private Vector3 destinoActual; //Marca mi destino actual.
    private void Awake()
    {
        foreach (Transform punto in ruta)
        {
            puntosDeRuta.Add(punto.position);
        }
        agent = GetComponent<NavMeshAgent>();

        destinoActual = puntosDeRuta[indicePuntoActual];
        StartCoroutine(PatrullarYEsperar());
    }
    private IEnumerator PatrullarYEsperar()
    {
        while (true)
        {
            agent.SetDestination(destinoActual); //Voy yendo al destino
            yield return new WaitUntil( ()=> !agent.pathPending && agent.remainingDistance <= 0.2f); //mE ESPERO en este punto hasta que llegue.
            yield return new WaitForSeconds(tiempoDeEspera); //Me espero en dicho punto.
            CalcularNuevoDestino();

        }
    }
    private void CalcularNuevoDestino()
    {
        indicePuntoActual++; //Avanzamos uno.
        indicePuntoActual = indicePuntoActual % (puntosDeRuta.Count); //Me aseguro de no salirme de los puntos máximos.
        destinoActual = puntosDeRuta[indicePuntoActual]; //Actualizo mi destino actual.

    }
    private void FixedUpdate()
    {
        Collider[] collsDetectados = Physics.OverlapSphere(transform.position, rangoVision, queEsTarget);
        if(collsDetectados.Length > 0) //Hay al menos un target dentro del rango. //1
        {
            Vector3 direccionATarget = (collsDetectados[0].transform.position - transform.position).normalized;

            if(!Physics.Raycast(transform.position, direccionATarget,rangoVision, queEsObstaculo)) //2
            {
                if(Vector3.Angle(transform.forward, direccionATarget) <= anguloVision / 2)
                {
                    this.enabled = false;
                }
            }

        }
    }
}
