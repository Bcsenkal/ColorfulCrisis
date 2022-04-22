using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infections : MonoBehaviour
{
    private PlayerController player;
    private BallSpawner ballSpawner;
    [SerializeField] private MaterialProvider materialProvider;
    [SerializeField] private float slowDownValue;
    [SerializeField] private float slowDownDuration;
    [SerializeField] private float preventToPickUpDuration;
    [SerializeField] private float stopSpawningDuration;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        ballSpawner = FindObjectOfType<BallSpawner>();
    }

    public void GetInfectionType(string color)
    {
        player.GetComponent<MeshRenderer>().material = materialProvider.GetMaterial(color);
        switch(color)
        {
            case "Blue":
                if(player.hasSlowedDownInfection)
                {
                    RestartCoroutine(SlowDownInfection());
                }
                else if(!player.hasSlowedDownInfection)
                {
                    StartCoroutine(SlowDownInfection());
                }
                break;
            case "Red":
                if(player.hasSpawnInfection)
                {
                    RestartCoroutine(DestroyAllBallsAndStopSpawningInfection());
                }
                else if(!player.hasSpawnInfection)
                {
                    StartCoroutine(DestroyAllBallsAndStopSpawningInfection());
                }
                break;
            case "Yellow":
            {
                if(player.hasPickUpInfection)
                {
                    RestartCoroutine(PreventToPickUpInfection());
                }
                else if(!player.hasSlowedDownInfection)
                {
                    StartCoroutine(PreventToPickUpInfection());
                }
                break;
            }
        }
    }

    public IEnumerator DestroyAllBallsAndStopSpawningInfection()
    {
        {
            player.hasSpawnInfection = true;
            var balls = FindObjectsOfType<Ball>();
            foreach(Ball ball in balls)
            {
                Destroy(ball.gameObject);
            }
            ballSpawner.canSpawn = false;
            yield return new WaitForSeconds(stopSpawningDuration);
            player.hasSpawnInfection = false;
            ballSpawner.canSpawn = true;
        }
        
    }

    public IEnumerator PreventToPickUpInfection()
    {
        player.hasPickUpInfection = true;
        yield return new WaitForSeconds(preventToPickUpDuration);
        player.hasPickUpInfection = false;
    }

    public IEnumerator SlowDownInfection()
    {
        player.hasSlowedDownInfection = true;
        player.currentSpeed = slowDownValue;
        yield return new WaitForSeconds(slowDownDuration);
        player.currentSpeed = player.defaultSpeed;
        player.hasSlowedDownInfection = false;
    }
    private void RestartCoroutine(IEnumerator coroutine)
    {
        StopCoroutine(coroutine);
        StartCoroutine(coroutine);
    }
}
