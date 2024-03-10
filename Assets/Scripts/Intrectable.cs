using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] Vector3 size;
    [SerializeField] LayerMask playerLayer;
    [SerializeField] bool isActive = true;
    [SerializeField] float activateTime = 1.0f;
    float t;
    GameManager gameManager;
    private void Start()
    {
        gameManager = GameManager.Instance;
    }
    private void Update()
    {
        if (Physics.CheckBox(transform.position + transform.forward, size * 0.5f, transform.rotation, playerLayer, QueryTriggerInteraction.Ignore))
        {
            if (Input.GetKey(KeyCode.E))
            {
                t += Time.deltaTime;
                if (t > activateTime)
                {
                    gameManager.checkIWinned();
                    isActive = false;
                    this.enabled = false;
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (!isActive) return;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position + transform.forward, size);
    }
}
