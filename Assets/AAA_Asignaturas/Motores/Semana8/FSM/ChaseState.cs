using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseState : State<EnemyController>
{
    [SerializeField]
    private float tiempoEsperaPathNoEncontrado;

    private Coroutine coroutine;

    public override void OnEnterState(EnemyController controller)
    {
        base.OnEnterState(controller);

        Debug.Log("Entro en el estado de perseguir!");
        controller.Agent.stoppingDistance = controller.DistanciaAtaque;
    }

    public override void OnUpdateState()
    {

        if(!controller.Agent.pathPending && controller.Agent.CalculatePath(controller.Target.position, new NavMeshPath()))
        {
            FinalizarCorrutinas();

            controller.Agent.SetDestination(controller.Target.position);
            if (!controller.Agent.pathPending && controller.Agent.remainingDistance <= controller.Agent.stoppingDistance)
            {
                FinalizarCorrutinas();
                controller.ChangeState(controller.AttackState);
            }
        }
        else
        {
            //Sólo se hace si la corrutina es nula. (oPERADOR de asignación de fusión nula) (asignar un valor sólo si la variable esta a nulo)
            coroutine ??= StartCoroutine(StopAndReturn());
        }
    }


    private IEnumerator StopAndReturn()
    {

        yield return new WaitForSeconds(tiempoEsperaPathNoEncontrado);
        controller.ChangeState(controller.PatrolState);
    }
    public override void OnExitState()
    {
        FinalizarCorrutinas();
    }
    private void FinalizarCorrutinas()
    {
        StopAllCoroutines();
        coroutine = null;
    }


}
