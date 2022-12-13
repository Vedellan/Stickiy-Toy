using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class EnemySetter : MonoBehaviour
{
    public Transform[] enemys;

    private void Start()
    {
        InvokeRepeating(nameof(CreateEnemy), 3f, 3f);
    }

    public void CreateEnemy()
    {
        enemys[0].position = SetRandomPosition();
        enemys[0].gameObject.SetActive(true);
    }

    Vector2 SetRandomPosition()
    {
        // half of height
        float ySize = Camera.main.orthographicSize + 1;
        // half of width
        float xSize = ySize * Camera.main.aspect + 1;

        Vector2 randomPosition;

        // 1 => top/bottom, 0 => left/right
        if (Random.Range(0, 2) == 1)
        {
            randomPosition.x = Random.Range(-xSize, xSize);

            // 1 = top, 0 = bottom
            if(Random.Range(0, 2) == 1)
            {
                randomPosition.y = ySize;
            }

            else
            {
                randomPosition.y = -ySize;
            }
        }

        else
        {
            randomPosition.y = Random.Range(-ySize, ySize);

            // 1 = right, 0 = left
            if(Random.Range(0, 2) == 1)
            {
                randomPosition.x = xSize;
            }

            else
            {
                randomPosition.x = -xSize;
            }
        }

        return randomPosition;
    }
}
