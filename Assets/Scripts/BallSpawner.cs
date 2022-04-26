using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField]private List<GameObject> ballPrefabs;
    private float spawnTimer;
    [SerializeField]private float spawnDelay;
    [SerializeField]private float spawnInterval;
    [SerializeField]private int spawnCount;
    [SerializeField]private int maxSpawnCount;
    [SerializeField]private float spawnOffset = 12f;
    [SerializeField]private float spawnCountIncrementTimer;
    [SerializeField]private float SpawnCountIncrementInterval;
    public bool canSpawn = false;
    
    private void Update() 
    {
        if(!FindObjectOfType<GameManager>().gameIsPaused)
        {
            Spawn();
            IncreaseSpawnCount();
            spawnTimer += Time.deltaTime;
            spawnCountIncrementTimer += Time.deltaTime;
        }
    }

    private void Spawn()
    {
        while(canSpawn && spawnTimer > spawnInterval)
        {
            for(int i = 0; i < spawnCount ; i++)
            {
                var ball = ballPrefabs[Random.Range(0,ballPrefabs.Count)];
                Instantiate(ball,GetRandomSpawnPoint(),ball.transform.rotation);
            }
            spawnTimer = 0;
        }
    }

    Vector3 GetRandomSpawnPoint()
    {
        return new Vector3(Random.Range(-spawnOffset,spawnOffset),spawnOffset,Random.Range(-spawnOffset,8f));
    }

    private void IncreaseSpawnCount()
    {
        while(canSpawn && spawnCount < maxSpawnCount && spawnCountIncrementTimer > SpawnCountIncrementInterval)
        {
            spawnCount += 1;
            spawnCountIncrementTimer = 0;
        }
    }
}
