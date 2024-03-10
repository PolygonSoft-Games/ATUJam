using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public Vector3 position;
    [SerializeField] public Path neighbour1, neighbour2;
    private void Awake()
    {
        position = transform.position;
        position.y = 0;
    }
}