using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infections : MonoBehaviour
{
    private PlayerController player;
    private BallSpawner ballSpawner;
    private InfectionManager infectionManager;
    [SerializeField] private MaterialProvider materialProvider;
    [SerializeField] private float slowDownValue;
    [SerializeField] private float slowDownDuration;
    [SerializeField] private float preventToPickUpDuration;
    [SerializeField] private float stopSpawningDuration;


    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        ballSpawner = FindObjectOfType<BallSpawner>();
        infectionManager = GetComponent<InfectionManager>();
    }

    public void GetInfectionType(string color)
    {
        player.GetComponent<MeshRenderer>().material = materialProvider.GetMaterial(color);
        switch(color)
        {
            case "Blue":
                infectionManager.slowDownTimer += slowDownDuration;
                SlowDownInfection();
                break;
            case "Red":
                infectionManager.stopSpawningTimer += stopSpawningDuration;
                DestroyAllBallsAndStopSpawningInfection();
                break;
            case "Yellow":
            {
                infectionManager.preventToPickUpTimer += preventToPickUpDuration;
                PreventToPickUpInfection();
                break;
            }
        }
    }

    public void DestroyAllBallsAndStopSpawningInfection()
    {
        player.hasSpawnInfection = true;
        var balls = FindObjectsOfType<Ball>();
        foreach(Ball ball in balls)
        {
            Destroy(ball.gameObject);
        }
        ballSpawner.canSpawn = false;
    }

    public void PreventToPickUpInfection()
    {
        player.hasPickUpInfection = true;
    }

    public void SlowDownInfection()
    {
        player.hasSlowedDownInfection = true;
        player.currentSpeed = slowDownValue;
    }    
}
