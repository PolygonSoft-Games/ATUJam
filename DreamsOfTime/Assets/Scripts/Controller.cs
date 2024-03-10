using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Controller : MonoBehaviour
{
    public static Controller Instance;

    float smoothDamp = 0.1f;


    private void Awake()
    {
        Instance = this;
        Application.targetFrameRate = 50;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void RotateBody(Transform obj, float TargetAngle, ref float vel)
    {
        float angle = Mathf.SmoothDampAngle(obj.eulerAngles.y, TargetAngle, ref vel, smoothDamp);
        obj.rotation = Quaternion.Euler(0, angle, 0);
    }
    private void MoveDirection(Transform obj, float TargetAngle, float Speed)
    {
        //Vector3 moveDirection = Quaternion.Euler(0, TargetAngle, 0) * Vector3.forward;
        obj.position += Quaternion.Euler(0, TargetAngle, 0) * Vector3.forward * Speed * Time.deltaTime;
        //obj.Translate(Quaternion.Euler(0, TargetAngle, 0) * Vector3.forward * Speed * Time.deltaTime, Space.World);

    }
    public void MoveAndRotateDir(Transform Obj, float angle, float speed, ref float _vel)
    {
        RotateBody(Obj, angle, ref _vel);
        MoveDirection(Obj, angle, speed);
    }

    public float CalcAngle(Vector3 direction)
    {
        return Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
    }
}
