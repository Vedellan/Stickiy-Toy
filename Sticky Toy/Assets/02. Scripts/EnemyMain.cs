using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMain : MonoBehaviour
{
    public Enemy myType = null;
    Vector2 moveVector = Vector2.zero;
    [SerializeField] float moveSpeed = 7f;

    private void OnEnable()
    {
        moveVector = new Vector2(-transform.position.x, -transform.position.y).normalized;
    }

    void Update()
    {
        MoveToCenter();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Flag"))
        {  
            gameObject.SetActive(false);
        }

        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            gameObject.SetActive(false);
        }
    }

    void MoveToCenter()
    {
        transform.Translate(moveSpeed * Time.deltaTime * moveVector);
    }
}
