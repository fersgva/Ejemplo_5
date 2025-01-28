using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private GameObject player;

    private NavMeshAgent agent;

    //Nada m�s comenzar el juego EST�S O NO EST�S ACTIVO
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }


    //SE produce s�lo una vez cuando ya has terminado la ejecuci�n del awake, onenable
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
