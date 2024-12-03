using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonFisicas : MonoBehaviour
{
    [SerializeField]
    private float fuerzaMovimiento;

    [SerializeField]
    private float velocidadMaxima;

    private Rigidbody rb;
    private float h, v;

    private bool puedoControlar = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

    }
    private void FixedUpdate() //0.02 segundos
    {
        rb.AddForce(new Vector3(h, 0, v).normalized * fuerzaMovimiento, ForceMode.Force);

        if(puedoControlar)
        {
            DelimitarVelocidad();

        }

    }

    private void DelimitarVelocidad()
    {
        Vector3 velocidadPlanoZX = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        Vector3 velocidadDelimitada = Vector3.ClampMagnitude(velocidadPlanoZX, velocidadMaxima);
        rb.velocity = new Vector3(velocidadDelimitada.x, rb.velocity.y, velocidadDelimitada.z);
        Debug.Log(rb.velocity);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Cilindro"))
        {
            puedoControlar = false;
        }
    }
}
