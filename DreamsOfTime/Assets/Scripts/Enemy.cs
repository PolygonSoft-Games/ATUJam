using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform target;
    private Vector3 initialPosition;

    public Vector3 targetPosition;

    void Start()
    {
        targetPosition = target.position;
        targetPosition.y = transform.position.y;
        initialPosition = transform.position;
    }

    void Update()
    {
        transform.LookAt(targetPosition);

        if(Vector3.Distance(transform.position, targetPosition) < 0.3f)
        {
            Vector3 temp = targetPosition;
            targetPosition = initialPosition;
            initialPosition = temp;
        }
    }
}
