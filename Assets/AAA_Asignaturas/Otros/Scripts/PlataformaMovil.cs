using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovil : MonoBehaviour
{
    [SerializeField]
    private float velocidadMovimiento;

    private Rigidbody rb;
    private Vector3 direccionMovimiento = new Vector3(-1, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        InvokeRepeating(nameof(MoverADireccion), 0, 3f);
    }
    void MoverADireccion()
    {
        direccionMovimiento *= -1;
        rb.velocity = direccionMovimiento * velocidadMovimiento;
    }
}
