using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;

    [SerializeField]
    private float gravityScale;

    [SerializeField]
    private float jumpHeight;


    [Header("Ground Detection")]
    [SerializeField]
    private Transform feet;

    [SerializeField]
    private float detectionRadius;

    [SerializeField]
    private LayerMask whatIsGround;

    private Vector3 verticalMovement;
    private CharacterController controller;
    private Camera cam;


    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        cam = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveAndRotate();
        ApplyGravity();
        Jump();

    }

    private void MoveAndRotate()
    {
        //Lectura de inputs
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector2 input = new Vector2(h, v).normalized;

        //Se calcula el �ngulo en base a los inputs Y (+) la c�mara
        float angleToRotate = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;

        //Se aplica dicha rotaci�n al cuerpo
        transform.eulerAngles = new Vector3(0, angleToRotate, 0);

        //Si hay input...
        if (input.sqrMagnitude > 0)
        {
            //Se rota el vector (0, 0, 1) a dicho �ngulo
            Vector3 movementInput = Quaternion.Euler(0, angleToRotate, 0) * Vector3.forward;

            //Se aplica movimiento en dicha direcci�n.
            controller.Move(movementInput * movementSpeed * Time.deltaTime);
        }
    }

    private void Jump()
    {
        if(IsGrounded())
        {
            verticalMovement.y = 0;

            if(Input.GetKeyDown(KeyCode.Space))
            {
                verticalMovement.y = Mathf.Sqrt(-2 * gravityScale * jumpHeight);
            }
        }
    }

    private void ApplyGravity()
    {
        verticalMovement.y += gravityScale * Time.deltaTime;
        controller.Move(verticalMovement * Time.deltaTime);
    }
    private bool IsGrounded()
    {
        return Physics.CheckSphere(feet.position, detectionRadius, whatIsGround);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(feet.position, detectionRadius);
    }
}
