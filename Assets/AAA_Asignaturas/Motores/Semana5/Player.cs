using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollingBall
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float velocidad;
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            float hInput = Input.GetAxisRaw("Horizontal"); //-1, 0, 1
            float vInput = Input.GetAxisRaw("Vertical"); //-1, 0, 1
            Vector3 direccionMovimiento = new Vector3(hInput, 0, vInput).normalized;

            transform.Translate(direccionMovimiento * velocidad * Time.deltaTime);


        }

        private void OnTriggerEnter(Collider other)
        {
            Destroy(other.gameObject);
        }
        private void OnTriggerStay(Collider other)
        {
            Debug.Log("Sigo tocando algo!");
        }
        private void OnTriggerExit(Collider other)
        {
            Debug.Log("Dejo de tocar algo!");
        }
    }

}
