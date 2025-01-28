using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerAI : MonoBehaviour
{
    [SerializeField]
    private EnemyAI enemyPrefab;

    [SerializeField]
    private int niveles;

    [SerializeField]
    private int oleadas;

    [SerializeField]
    private int enemigosPorOleada;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawnear());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //MÉTODO EJECUTADO POR INTERVALOS. (RUTINA)
    private IEnumerator Spawnear()
    {
        for (int i = 0; i < niveles; i++) //5
        {
            for (int j = 0; j < oleadas;  j++) //8
            {
                for (int k = 0; k < enemigosPorOleada; k++) //10
                {
                    Instantiate(enemyPrefab, transform.position, Quaternion.identity);
                    yield return new WaitForSeconds(1f);
                }
                yield return new WaitForSeconds(1.5f);
            }
            yield return new WaitForSeconds(4f);
        }


    }
}
