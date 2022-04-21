using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField]private List<GameObject> ballPrefabs;
    [SerializeField]private float spawnDelay;
    [SerializeField]private float spawnInterval;
    [SerializeField]private int spawnCount;
    [SerializeField]private float spawnOffset = 12f;
    [SerializeField]private float IncreaseSpawnCountInterval;
    void Start()
    {
        InvokeRepeating("Spawn",spawnDelay,spawnInterval);
        StartCoroutine(IncreaseSpawnCount());
    }
    
    void Spawn()
    {
        for(int i = 0; i < spawnCount ; i++)
        {
            var ball = ballPrefabs[Random.Range(0,ballPrefabs.Count)];
            Instantiate(ball,GetRandomSpawnPoint(),ball.transform.rotation);
        }
    }
    Vector3 GetRandomSpawnPoint()
    {
        return new Vector3(Random.Range(-spawnOffset,spawnOffset),spawnOffset,Random.Range(-spawnOffset,8f));
    }
    IEnumerator IncreaseSpawnCount()
    {
        do
        {
            yield return new WaitForSeconds(IncreaseSpawnCountInterval);
            spawnCount += 1;
        }
        while(spawnCount < 5);
    }
}
