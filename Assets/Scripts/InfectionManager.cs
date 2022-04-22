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
}
