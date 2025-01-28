using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasEstructuras : MonoBehaviour
{
    private float ejempo;

    private struct Stats
    {
        public float hp;
        public float ataque;
        public float defensa;

    }
    // Start is called before the first frame update
    void Start()
    {
       Stats misStats = new Stats();
        misStats.ataque = 5f;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
