using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    [SerializeField]
    private Vector3 movingDirection;

    [SerializeField]
    private float movingSpeed;

    [SerializeField]
    private float movingDistance;

    private Vector3 initialPosition;

    private Vector3 pointA, pointB;

    private Vector3 destinationPoint;

    private void Awake()
    {
        initialPosition = transform.position;
        pointA = initialPosition + movingDirection * movingDistance;
        pointB = initialPosition - movingDirection * movingDistance;
        destinationPoint = pointA;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, destinationPoint, movingSpeed * Time.deltaTime);
        if(transform.position == destinationPoint)
        {
            destinationPoint = destinationPoint == pointA ? pointB : pointA;
        }
    }
}
