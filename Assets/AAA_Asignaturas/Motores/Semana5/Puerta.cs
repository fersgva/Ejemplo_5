using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    [SerializeField] private Motores.GameManagerSO gM;
    [SerializeField] private int idPuerta;

    private bool abrir = false;
    // Start is called before the first frame update
    void Start()
    {
        gM.OnNuevaInteraccion += Abrir;    
    }

    private void Abrir(int idBotonPulsado)
    {
        if(idBotonPulsado == idPuerta)
        {
            abrir = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(abrir)
        {
            transform.Translate(Vector3.down * 5 * Time.deltaTime);
        }
    }
}
