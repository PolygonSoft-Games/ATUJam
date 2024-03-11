using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScripts : MonoBehaviour
{
    [SerializeField] float interactDistance = 2.0f;

    [SerializeField] GameObject talks;
    [SerializeField] LayerMask itemLayer;

    [SerializeField] GameObject nextItem;

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, Vector3.one * interactDistance);
    }

    void Update()
    {
        Vector3 halfExtents = Vector3.one * interactDistance;
        if (Physics.CheckBox(transform.position, halfExtents, Quaternion.identity, itemLayer))
        {
            if (Input.GetKey(KeyCode.E))
            {
                talks.SetActive(true);
                nextItem.SetActive(true);
            }
        }
        else
        {
            talks.SetActive(false);
        }
    }
}
