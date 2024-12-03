using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private float tiempoEntreSpawns;

    [SerializeField]
    private Transform[] spawnPoints;

    private IEnumerator Start()
    {
        while (true)
        {
            Instantiate(enemyPrefab, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
            yield return new WaitForSeconds(tiempoEntreSpawns);
        }
        
    }

    private void Update()
    {
        tiempoEntreSpawns -= 0.05f * Time.deltaTime;
        if(tiempoEntreSpawns < 0.5f)
        {
            tiempoEntreSpawns = 0.5f;
        }
    }
}
