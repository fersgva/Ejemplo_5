using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State<EnemyController>
{
    [SerializeField] private float attackDistance;
    [SerializeField] private float timeBetweenAttacks;

    private Transform target;

    private float timer = 0;
    public override void OnEnterState(EnemyController controller)
    {
        base.OnEnterState(controller);
        timer = timeBetweenAttacks;
    }
    public override void OnUpdateState()
    {
        timer += Time.deltaTime;
        if(timer > timeBetweenAttacks)
        {
            Debug.Log("Te ataco!");
            timer = 0f;
        }

        if (Vector3.Distance(transform.position, target.position) > attackDistance)
        {
            controller.ChangeState(controller.ChaseState);
        }
    }
    public override void OnExitState()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            target = player.transform;
        }
    }

}
