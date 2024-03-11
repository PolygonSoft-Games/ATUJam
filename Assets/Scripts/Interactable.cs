using JetBrains.Annotations;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] float interactDistance = 2.0f;
    [SerializeField] LayerMask itemLayer;

    [SerializeField] GameObject npc;

    [SerializeField]
    [CanBeNull] GameObject nextNpc;

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, Vector3.one * interactDistance);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteract();
        }
    }

    void TryInteract()
    {
        Vector3 halfExtents = Vector3.one * interactDistance;
        if (Physics.CheckBox(transform.position, halfExtents, Quaternion.identity, itemLayer))
        {
            gameObject.SetActive(false);
            npc.SetActive(false);
            nextNpc.SetActive(true);
        }
    }
}
