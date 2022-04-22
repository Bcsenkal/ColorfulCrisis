using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectionManager : MonoBehaviour
{
    private PlayerController player;
    private BallControls ball;
    private Infections infections;
    private BallSpawner ballSpawner;
    [SerializeField] private MaterialProvider materialProvider;
    [Header("HoldTimer")]
    public float holdTimer;
    public float maxHoldDuration;
    [Header("InfectionTimers")]
    [SerializeField] public float slowDownTimer;
    [SerializeField] public float preventToPickUpTimer;
    [SerializeField] public float stopSpawningTimer;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        ball = GameObject.Find("Player").GetComponent<BallControls>();
        infections = GetComponent<Infections>();
        ballSpawner = FindObjectOfType<BallSpawner>();
    }

    void Update()
    {
        HoldTimer();
        Infection();
        CheckCurrentInfections();
        InfectionCountdowns();
    }

    private void HoldTimer()
    {
        if(player.hasBall)
        {
            holdTimer += Time.deltaTime;
        }
        if(!player.hasBall)
        {
            holdTimer = 0;
        }
    }
    private void Infection()
    {
        if(holdTimer > maxHoldDuration && ball.currentBall != null)
        {
            infections.GetInfectionType(ball.currentBall.gameObject.GetComponent<Ball>().color);
            Destroy(ball.currentBall);
        }
    }
    public void CheckCurrentInfections()
    {
        if(preventToPickUpTimer <= 0)
        {
            preventToPickUpTimer = 0;
            player.hasPickUpInfection = false;
        }
        if(slowDownTimer <= 0)
        {
            slowDownTimer = 0;
            player.currentSpeed = player.defaultSpeed;
            player.hasSlowedDownInfection = false;
        }
        if(stopSpawningTimer <= 0)
        {
            stopSpawningTimer = 0;
            player.hasSpawnInfection = false;
            ballSpawner.canSpawn = true;
        }
    }
        public void InfectionCountdowns()
    {
        if(slowDownTimer > 0)
        {
            slowDownTimer -= Time.deltaTime;
        }
        if(stopSpawningTimer > 0)
        {
            stopSpawningTimer -= Time.deltaTime;
        }
        if(preventToPickUpTimer > 0)
        {
            preventToPickUpTimer -= Time.deltaTime;
        }
    }
}
