using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;
    public float speed = 0f;
    public static SampleController Instance;

    void Awake()
    {

        animator = GetComponent<Animator>();
        Instance = this;

    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            speed = 1f;
            animator.SetFloat("Speed", speed);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = 2.1f;
                animator.SetFloat("Speed", speed);
            }
            else
            {
                speed = 1f;
                animator.SetFloat("Speed", speed);
            }
        }
        else
        {
            speed = 0f;
            animator.SetFloat("Speed", speed);
        }


        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
    }
}
