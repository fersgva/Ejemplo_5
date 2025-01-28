using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuboOro : MonoBehaviour
{
    [SerializeField] private float velocidadRotacion;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * velocidadRotacion * Time.deltaTime, Space.World);
    }
    private void OnTriggerEnter(Collider other)
    {
        
    }
}
