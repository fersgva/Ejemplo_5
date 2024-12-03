using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSystem : MonoBehaviour
{
    protected Player main;
    protected virtual void Awake()
    {
        main = transform.root.GetComponent<Player>();
    }
}
