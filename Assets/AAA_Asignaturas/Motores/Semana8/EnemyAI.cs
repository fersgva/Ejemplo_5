using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private GameObject player;

    private NavMeshAgent agent;

    //Nada más comenzar el juego ESTÉS O NO ESTÉS ACTIVO
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }


    //SE produce sólo una vez cuando ya has terminado la ejecución del awake, onenable
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerDynamic>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.transform.position);
    }
}
