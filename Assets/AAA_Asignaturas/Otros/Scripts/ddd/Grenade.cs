using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField]
    private float impulseForce;

    [SerializeField]
    private float lifeTime;

    [SerializeField]
    private float explosionForce;

    [SerializeField]
    private float explosionRadius;

    [SerializeField]
    private LayerMask whatIsDamagable;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        //Vector3 forceDirection = (transform.forward + transform.up).normalized;
        GetComponent<Rigidbody>().AddForce(transform.forward * impulseForce, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > lifeTime)
        {
            //Sistema de particulas de explosión.
            Collider[] collidersDetected = Physics.OverlapSphere(transform.position, explosionRadius, whatIsDamagable);
            foreach (Collider coll in collidersDetected)
            {
                Rigidbody rbDetected = coll.GetComponent<Rigidbody>();
                rbDetected.isKinematic = false;
                rbDetected.AddExplosionForce(explosionForce, transform.position, explosionRadius, 1.5f, ForceMode.Impulse);
            }
            Destroy(this.gameObject);
        }
    }
}
