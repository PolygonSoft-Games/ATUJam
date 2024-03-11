using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    private Controller controller;

    [SerializeField] Animator animator;

    private Transform cam;
    private PlayerState _state;

    bool move;

    float vel;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        if (cam == null)
        {
            cam = Camera.main.transform;
        }
    }

    private void Start()
    {
        controller = Controller.Instance;
    }

    private void Update()
    {
        move = Inputs().sqrMagnitude > 0.1f;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            vel = 4f;
            animator.SetFloat("Speed", 3f);
        }
        else
        {
            vel = 1.5f;

            if (move)
            {
                animator.SetFloat("Speed", 1f);
            }
            else
            {
                animator.SetFloat("Speed", 0f);
            }
        }
    }

    private void FixedUpdate()
    {
        if (move)
        {
            controller.MoveAndRotateDir(this.transform, controller.CalcAngle(Inputs()) + cam.eulerAngles.y, vel, ref vel);
        }
    }

    float xInput;
    float yInput;

    private Vector3 Inputs()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
        return new Vector3(xInput, 0, yInput).normalized;
    }

    public Vector3 getPosition()
    {
        return transform.position;
    }

    public void setAnimationState()
    {
        switch (_state)
        {
            case PlayerState.idle:
                break;
            case PlayerState.run:
                break;
            case PlayerState.die:
                break;
            case PlayerState.interaction:
                break;
        }
    }

    public void setState(PlayerState state)
    {
        _state = state;
        setAnimationState();
    }

    public PlayerState getState()
    {
        return _state;
    }
}

public enum PlayerState { idle, run, die, interaction }
