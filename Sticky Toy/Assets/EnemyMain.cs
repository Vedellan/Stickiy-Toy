using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMain : MonoBehaviour
{
    public Enemy myType;

    void Update()
    {
        MoveToCenter();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Flag"))
        {
            GameManager.instance.onGameOver.Invoke();
        }
    }

    void MoveToCenter()
    {
        transform.position = Vector2.Lerp(transform.position, Vector2.zero, Time.deltaTime);
    }
}
