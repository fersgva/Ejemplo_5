using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : Controller
{

    private Transform target;


    [SerializeField]
    private float rangoVision;

    [SerializeField]
    private float anguloVision;

    [SerializeField]
    private LayerMask queEsTarget;

    [SerializeField]
    private LayerMask queEsObstaculo;



    private NavMeshAgent agent;
    private PatrolState patrolState;
    private ChaseState chaseState;
    private AttackState attackState;

    private State<EnemyController> currentState;

    public PatrolState PatrolState { get => patrolState;}
    public ChaseState ChaseState { get => chaseState;}
    public AttackState AttackState { get => attackState;}
    public NavMeshAgent Agent { get => agent;}
    public float RangoVision { get => rangoVision;  }
    public float AnguloVision { get => anguloVision;  }
    public LayerMask QueEsTarget { get => queEsTarget; }
    public LayerMask QueEsObstaculo { get => queEsObstaculo; }
    public Transform Target { get => target; set => target = value; }

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        patrolState = GetComponent<PatrolState>();
        chaseState = GetComponent<ChaseState>();
        attackState = GetComponent<AttackState>();

        ChangeState(patrolState);
    }

    // Update is called once per frame
    void Update()
    {
        //Si tengo un estado el cual actualizar...
        currentState?.OnUpdateState(); //Pido que se atualice.
    }
    public void ChangeState(State<EnemyController> newState)
    {
        //Antes de cambiar, si estábamos en un estado anterior...
        //Tendré que salir de este estado.
        currentState?.OnExitState();

        //Y ahora mi estado actual es este.
        currentState = newState;

        //Por último, tendré que pedir que este estado se inicie.
        currentState.OnEnterState(this);
    }
}
