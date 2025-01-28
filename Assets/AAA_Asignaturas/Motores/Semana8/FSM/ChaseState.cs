using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State<EnemyController>
{
    [SerializeField] private float chaseVelocity;
    [SerializeField] private float stoppingDistance;
    public override void OnEnterState(EnemyController controller)
    {
        base.OnEnterState(controller);
    }
    public override void OnUpdateState()
    {
        if(controller.Target)
        {
            controller.Agent.SetDestination(controller.Target.position); //Voy yendo al destino
        }
    }
    public override void OnExitState()
    {
        
    }


}
