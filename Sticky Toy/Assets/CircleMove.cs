using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CircleMove : MonoBehaviour
{
    VariableJoystick variableJoystick;

    Rigidbody2D rb;
    Vector2 moveVector;
    public float moveSpeed = 20f;

    Vector2 limitPos;
    public float limitLength  = 3f;
    public float limitVelocity = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        variableJoystick = GameObject.Find("Variable Joystick").GetComponent<VariableJoystick>();
    }

    private void Update()
    {
        transform.position = ClampCirclePosition();
        rb.velocity = ClampCircleVelocity();
        transform.rotation = SmoothChangeRotation();
        
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        moveVector = variableJoystick.Direction;
        rb.AddForce(moveSpeed * Time.deltaTime * moveVector, ForceMode2D.Force);
    }

    Vector2 ClampCirclePosition()
    {
        // Circle의 포지션을 원형으로 제한
        return Vector2.ClampMagnitude(transform.position, limitLength);
    }

    Vector2 ClampCircleVelocity()
    {
        return Vector2.ClampMagnitude(rb.velocity, limitVelocity);
    }

    Quaternion SmoothChangeRotation()
    {
        float angle = Mathf.Atan2(variableJoystick.Horizontal, variableJoystick.Vertical) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(-angle, Vector3.forward);
        return rotation;
    }
}
