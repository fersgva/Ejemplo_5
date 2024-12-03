using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estructuras : MonoBehaviour
{
    [SerializeField] private float vida;

    private enum Fase { Fase1,  Fase2, Fase3 };
    private Fase faseBoss;
    // Start is called before the first frame update
    void Start()
    {
        
        if(vida >= 50 && vida < 100) //75
        {
            Debug.Log("Estamos en verde!"); //75
        }
        else if(vida >= 25 && vida < 50)
        {
            Debug.Log("Estamos en naranja :|");
        }
        else if(vida > 0 && vida < 25)
        {
            Debug.Log("Estamos en rojo :(");
        }
        else
        {
            Debug.Log("Estamos muertos X(");
        }

        switch (faseBoss)
        {
            case Fase.Fase1:
                Debug.Log("Estoy muerto");
                break;
            case Fase.Fase2:
                Debug.Log("Me queda un golpe!");
                break;
            case Fase.Fase3:
                Debug.Log("No estoy mal");
                break;
            //case 3:
            //    Debug.Log("Estoy a tope!");
            //    break;
            default:
                Debug.Log("Estoy repleto de vida!");
                break;
        }

        switch (vida)
        {
            case 0:
                Debug.Log("Estoy muerto");
                break;
            case 1:
                Debug.Log("Me queda un golpe!");
                break;
            case 2:
                Debug.Log("No estoy mal"); 
                break;
            case 3:
                Debug.Log("Estoy a tope!");
                break;
            default:
                Debug.Log("Estoy repleto de vida!");
                break;
        }

        //if
        //if-else
        //if-else if: OPCIONAL (1: Te aseguras que el código sólo esté en un rango al mismo tiempo
        //2. Cuando l





    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
