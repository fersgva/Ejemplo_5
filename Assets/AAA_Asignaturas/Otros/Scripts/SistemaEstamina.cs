using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaEstamina : PlayerSystem
{
    [SerializeField]
    private InputManagerSO inputManager;

    [SerializeField]
    private GameManagerSO gM;

    [SerializeField]
    private float estaminaMaxima;

    [SerializeField]
    private float factorDecrecimiento;

    [SerializeField]
    private float factorRecuperacion;

    [SerializeField]
    private float factorCansado;

    [SerializeField]
    private float velocidadCorrer;

    [SerializeField]
    private float velocidadCansado;



    private bool corriendo; 
    private bool cansado;
    private float estaminaActual;

    private void OnEnable()
    {
        //Expresión LAMBDA
        inputManager.OnCorrerStarted += () => corriendo = true;
        inputManager.OnCorrerCanceled += () => corriendo = false;
    }
    protected override void Awake()
    {
        base.Awake();


    }

    // Start is called before the first frame update
    void Start()
    {
        estaminaActual = estaminaMaxima;
    }

    // Update is called once per frame
    void Update()
    {
        //Si corremos y no estamos cansados y nos movemos...
        if(corriendo && !cansado)
        {
            if(estaminaActual > 0) //Y nos queda estamina....
            {
                ConsumirEstamina();
            }
            else //Voy a entrar en el estado de cansado.
            {
                EstaminaGastada();   
            }
        }
        else //Recuperación
        {
            if(estaminaActual < estaminaMaxima)
            {
                RecuperarEstamina();
            }
            else //Recuperado
            {
                EstaminaRecuperada();
            }
        }
    }

    //private void EmpezarCarrera()
    //{
    //    corriendo = true;
    //}

    //private void TerminarCarrera()
    //{
    //    corriendo = false;
    //}

    private void ConsumirEstamina()
    {
        main.VelocidadMovimientoActual = velocidadCorrer;
        estaminaActual -= factorDecrecimiento * Time.deltaTime;
        if(estaminaActual < 0)
        {
            estaminaActual = 0;
        }

        gM.ActualizarStamina(estaminaActual, estaminaMaxima);
    }
    private void RecuperarEstamina()
    {
        float factorAAplicar = cansado ? factorCansado : factorDecrecimiento;
        main.VelocidadMovimientoActual = main.VelocidadPorDefecto;

        estaminaActual += factorAAplicar * Time.deltaTime;

        if(estaminaActual > estaminaMaxima)
        {
            estaminaActual=estaminaMaxima;
        }

        gM.ActualizarStamina(estaminaActual, estaminaMaxima);
    }
    private void EstaminaGastada()
    {
        cansado = true;
        main.VelocidadMovimientoActual = velocidadCansado;
        gM.PlayerCansado();
    }
    private void EstaminaRecuperada()
    {
        cansado = false;
        gM.PlayerRecuperado();
    }

    private void OnDisable()
    {
    
    }


}
