using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : PlayerSystem
{

    //IMPORTANTE: Si queremos que rote junto con la cámara es tan fácil como aplicar el FirstPersonController.

    [SerializeField]
    private InputManagerSO inputManager;

    [SerializeField]
    private float movementSpeed;

    [SerializeField]
    private float rotationSmoothFactor;

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
    private Animator anim;
    private Camera cam;
    private float rotationVelocity;

    private Vector3 movimiento;


    protected override void Awake()
    {
        base.Awake();
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        cam = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;

        main.VelocidadPorDefecto = movementSpeed;
        main.VelocidadMovimientoActual = movementSpeed;

    }

    private void OnEnable()
    {
        inputManager.OnMoverStarted += LeerMovimiento;
        inputManager.OnMoverCanceled += CancelarMovimiento;
    }
    private void LeerMovimiento(Vector2 direccionJoystick)
    {
        movimiento = new Vector3(direccionJoystick.x, 0, direccionJoystick.y);
    }

    private void CancelarMovimiento()
    {
        movimiento = Vector3.zero;
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
        //Si hay input...
        if (movimiento.sqrMagnitude > 0)
        {
            //Se calcula el ángulo en base a los inputs Y (+) la cámara
            float angleToRotate = Mathf.Atan2(movimiento.x, movimiento.z) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;

            float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, angleToRotate, ref rotationVelocity, rotationSmoothFactor);

            //Se aplica dicha rotación al cuerpo
            transform.eulerAngles = new Vector3(0, smoothAngle, 0);

            //Se rota el vector (0, 0, 1) a dicho ángulo
            Vector3 movementInput = Quaternion.Euler(0, angleToRotate, 0) * Vector3.forward;

            //Se aplica movimiento en dicha dirección.
            controller.Move(movementInput * main.VelocidadMovimientoActual * Time.deltaTime);

            anim.SetBool("walking", true);
        }
        else
        {
            anim.SetBool("walking", false);
        }
    }

    private void Jump()
    {
        if (IsGrounded())
        {
            verticalMovement.y = 0;

            if (Input.GetKeyDown(KeyCode.Space))
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


    private void OnDisable()
    {
        inputManager.OnMoverStarted -= LeerMovimiento;
        inputManager.OnMoverCanceled -= CancelarMovimiento;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(feet.position, detectionRadius);
    }
}
