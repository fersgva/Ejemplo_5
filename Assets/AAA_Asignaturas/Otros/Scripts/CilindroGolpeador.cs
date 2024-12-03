using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CilindroGolpeador : MonoBehaviour
{
    [SerializeField]
    private float impulsoInicial;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddTorque(new Vector3(0, 1, 0) * impulsoInicial, ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
