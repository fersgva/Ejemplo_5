using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody[] rbs;

    [SerializeField]
    private float lifes;

    public float Lifes { get => lifes; set => lifes = value; }

    private void Awake()
    {
        rbs = GetComponentsInChildren<Rigidbody>();

        ChangeBonesState(true);
    }

    private void ChangeBonesState(bool state)
    {
        foreach (Rigidbody rb in rbs)
        {
            rb.isKinematic = state;
        }
    }

    public void TakeDamage(float damage)
    {
        lifes -= damage;

        if(lifes <= 0 )
        {
            ChangeBonesState(false);
        }
    }
}
