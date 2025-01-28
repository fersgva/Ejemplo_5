using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Motores
{
    [CreateAssetMenu(menuName = "MiGameManager")]
    public class GameManagerSO : ScriptableObject
    {
        public event Action<int> OnNuevaInteraccion;
        public void InteractuableEjecutado(int idInteraccion)
        {
            //Lanzar un evento de que un botòn ha sido pulsado.
            OnNuevaInteraccion?.Invoke(idInteraccion);
        }
    }
}

