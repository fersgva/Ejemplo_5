using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVisual : MonoBehaviour
{
    private EnemyController controller;
    private Animator anim;

    private void Awake()
    {
        controller = transform.root.GetComponent<EnemyController>();
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("velocity", controller.Agent.velocity.magnitude / controller.Agent.speed);
    }
}
