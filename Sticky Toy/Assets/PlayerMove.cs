using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    PlayerControl playerControl;
    VariableJoystick variableJoystick;

    Rigidbody2D rb;
    Vector2 moveVector;
    public float moveSpeed = 20f;

    Vector2 limitPos;
    public float limitLength  = 3f;
    public float limitVelocity = 5f;

    private void Awake()
    {
        playerControl = new PlayerControl();
    }

    private void OnEnable()
    {
        playerControl.Enable();
    }

    private void OnDisable()
    {
        playerControl.Disable();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        /*variableJoystick = GameObject.Find("Variable Joystick").GetComponent<VariableJoystick>();*/
    }

    private void Update()
    {
        transform.position = ClampCirclePosition();
        rb.velocity = ClampCircleVelocity();
        /*transform.rotation = SmoothChangeRotation();*/
    }

    void FixedUpdate()
    {
        OnMove();
    }

    private void Move()
    {
        /* Android Move
        moveVector = variableJoystick.Direction;
        */
        rb.AddForce(moveSpeed * Time.deltaTime * moveVector, ForceMode2D.Force);
    }
    public void OnMove()
    {
        moveVector = playerControl.PlayerAction.Move.ReadValue<Vector2>();
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
