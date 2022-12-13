using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class EnemySetter : MonoBehaviour
{
    public Transform[] enemys;
    Coroutine spawnEnemy;
    float spawnTime = 3f;

    private void Start()
    {
        spawnEnemy = StartCoroutine(CreateEnemy());
        GameManager.instance.onGameStart.AddListener(SpawnEnemy);
    }

    private void SpawnEnemy()
    {
        if(spawnEnemy != null)
        {
            StopCoroutine(spawnEnemy);
        }

        spawnEnemy = StartCoroutine(CreateEnemy());
    }

    public IEnumerator CreateEnemy()
    {
        while(true)
        {
            enemys[0].position = SetRandomPosition();
            enemys[0].gameObject.SetActive(true);
            yield return new WaitForSeconds(spawnTime);
        }
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
