using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMove : MonoBehaviour
{
    [SerializeField]
    VariableJoystick variableJoystick;
    [SerializeField]
    Rigidbody2D rb;
    [SerializeField]
    Vector2 moveVector;
    public float moveSpeed = 10;
    Vector2 limitPos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        variableJoystick = GameObject.Find("Variable Joystick").GetComponent<VariableJoystick>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveVector = variableJoystick.Direction;

        rb.AddForce(moveSpeed * Time.deltaTime * moveVector, ForceMode2D.Force);

        limitPos = ClampCirclePosition();
        transform.position = limitPos;
    }

    Vector2 ClampCirclePosition()
    {
        return Vector2.ClampMagnitude(moveVector, 30f);
    }
}
