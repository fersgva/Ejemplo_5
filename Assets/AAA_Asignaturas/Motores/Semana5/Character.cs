using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private CharacterController controller;
    [SerializeField] private float velocidad;
    [SerializeField] private float factorGravedad;

    private Vector3 movimientoVertical;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();    
    }

    // Update is called once per frame
    void Update()
    {
        float hInput = Input.GetAxisRaw("Horizontal"); //-1, 0, 1
        float vInput = Input.GetAxisRaw("Vertical"); //-1, 0, 1
        Vector3 direccionMovimiento = new Vector3(hInput, 0, vInput).normalized;
        controller.Move(direccionMovimiento * velocidad * Time.deltaTime);

        AplicarGravedad();
    }
    private void AplicarGravedad()
    {
        movimientoVertical.y += factorGravedad * Time.deltaTime;
        controller.Move(movimientoVertical * Time.deltaTime);
    }
}
