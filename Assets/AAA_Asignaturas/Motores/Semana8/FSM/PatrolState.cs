using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PatrolState : State<EnemyController>
{
    [SerializeField] private Transform route;
    [SerializeField] private float velocidadPatrulla;
    [SerializeField] private float tiempoDeEspera;

    private List<Vector3> listadoPuntos = new List<Vector3>();

    private Vector3 currentDestination;
    private int currentDestinationIndex;
    public override void OnEnterState(EnemyController controller)
    {
        base.OnEnterState(controller);
        foreach (Transform t in route)
        {
            //Establezco los puntos de ruta por los que pasa el murciélago.
            listadoPuntos.Add(t.position);
        }

        currentDestination = listadoPuntos[currentDestinationIndex];
        StartCoroutine(PatrullarYEsperar());

    }
    public override void OnUpdateState()
    {
        Collider[] collsDetectados = Physics.OverlapSphere(transform.position, controller.RangoVision, controller.QueEsTarget);
        if (collsDetectados.Length > 0) //Hay al menos un target dentro del rango. //1
        {
            Vector3 direccionATarget = (collsDetectados[0].transform.position - transform.position).normalized;

            if (!Physics.Raycast(transform.position, direccionATarget, controller.RangoVision, controller.QueEsObstaculo)) //2
            {
                if (Vector3.Angle(transform.forward, direccionATarget) <= controller.AnguloVision / 2)
                {
                    controller.Target = collsDetectados[0].transform;
                    controller.ChangeState(controller.ChaseState);
                }
            }

        }
    }
    private IEnumerator PatrullarYEsperar()
    {
        while (true)
        {
            controller.Agent.SetDestination(currentDestination); //Voy yendo al destino
            yield return new WaitUntil(() => !controller.Agent.pathPending && controller.Agent.remainingDistance <= 0.2f); //mE ESPERO en este punto hasta que llegue.
            yield return new WaitForSeconds(tiempoDeEspera); //Me espero en dicho punto.
            CalcularNuevoDestino();

        }
    }

    private void CalcularNuevoDestino()
    {
        currentDestinationIndex++; //Avanzamos uno.
        currentDestinationIndex = currentDestinationIndex % (listadoPuntos.Count); //Me aseguro de no salirme de los puntos máximos.
        currentDestination = listadoPuntos[currentDestinationIndex]; //Actualizo mi destino actual.

    }

    public override void OnExitState()
    {
        listadoPuntos.Clear();
        currentDestinationIndex = 0;
    }

}
