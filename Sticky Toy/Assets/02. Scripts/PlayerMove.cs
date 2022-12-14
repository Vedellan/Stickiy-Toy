using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    PlayerControl playerControl;
    VariableJoystick variableJoystick;

    Rigidbody2D rb;
    Vector3 startPosition;
    Vector2 moveVector;
    public float moveSpeed = 25f;

    Vector2 limitPos;
    public float limitLength  = 3f;
    public float limitVelocity = 20f;
    public float deathThreshold = 38.44f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerControl = new PlayerControl();
        startPosition = new Vector3(0, -3, 0);
    }

    private void OnEnable()
    {
        playerControl.Enable();
    }

    private void OnDisable()
    {
        playerControl.Disable();
        GameManager.Instance.onGameStart.RemoveListener(GameStart_Player);
        GameManager.Instance.onGameStart.RemoveListener(GameOver_Player);
    }

    void Start()
    {
        GameManager.Instance.onGameStart.AddListener(GameStart_Player);
        GameManager.Instance.onGameStart.AddListener(GameOver_Player);
        /*variableJoystick = GameObject.Find("Variable Joystick").GetComponent<VariableJoystick>();*/
    }

    private void Update()
    {
        CheckOutSafeZone();
        rb.velocity = ClampCircleVelocity();
        /*transform.rotation = SmoothChangeRotation();*/
    }

    void FixedUpdate()
    {
        OnMove();
    }

    void GameStart_Player()
    {
        SetStartPosition();
    }

    void GameOver_Player()
    {
        rb.velocity = Vector2.zero;
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

    void SetStartPosition()
    {
        transform.position = startPosition;
    }

    void CheckOutSafeZone()
    {
        if(transform.position.sqrMagnitude >= deathThreshold)
        {
            GameManager.Instance.onGameOver.Invoke();
        }
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

    void PlayerDeadEffect()
    {

    }
}
