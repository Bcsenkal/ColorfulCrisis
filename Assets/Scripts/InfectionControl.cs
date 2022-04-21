using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectionControl : MonoBehaviour
{
    private PlayerController player;
    private BallControls ball;
    private Infections infections;
    private bool playerIsInfected;
    public float holdTimer;
    void Start()
    {
        player = GetComponent<PlayerController>();
        ball = GetComponent<BallControls>();
        infections = GetComponent<Infections>();
    }

    void Update()
    {
        TimerControl();
    }

    private void TimerControl()
    {
        if(ball.hasBall)
        {
            holdTimer += Time.deltaTime;
        }
        if(!ball.hasBall)
        {
            holdTimer = 0;
        }
    }
    private void GetInfected()
    {
        if(ball.hasBall && holdTimer > 5 && !playerIsInfected)
        {
            playerIsInfected = true;
        }
    }
}
