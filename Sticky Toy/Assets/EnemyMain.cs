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
        if (collision.gameObject.layer == LayerMask.NameToLayer("Flag"))
        {  
            GameManager.instance.onGameOver.Invoke();
            gameObject.SetActive(false);
        }

        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            gameObject.SetActive(false);
        }
    }

    void MoveToCenter()
    {
        transform.position = Vector2.Lerp(transform.position, Vector2.zero, Time.deltaTime);
    }
}
