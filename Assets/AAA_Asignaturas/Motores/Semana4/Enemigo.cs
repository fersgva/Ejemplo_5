using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private float alturaSalto;
    private Personaje player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Personaje>();
        player.RecibirDanho(20);
    }

    // Update is called once per frame
    void Update()
    {
        //if(player cerca)
        {
            //Enemigo saltar alturaSalto metros de salto.
        }
    }
}
