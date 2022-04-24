using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public bool isOnGround;
    public bool playerHoldingThis;
    private Rigidbody ballRb;
    [SerializeField] public string color;
    [SerializeField] private float groundTimer;
    [SerializeField] private float maxGroundTime;
    
    void Awake()
    {
        isOnGround = false;
        color = gameObject.name.Replace("(Clone)","");
    }
    
    void Start()
    {
        ballRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfPlayerHolding();
        GroundTimer();
        DestroyIfOnGround();
    }
    
    private void OnCollisionStay(Collision other) 
    {
        if(other.gameObject.tag == "Ground" || other.gameObject.tag == "BoxWall")
        {
            if(ballRb.velocity == Vector3.zero)
            isOnGround = true;
        }
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Sensor")
        {
            if(other.GetComponent<LiquidSpawner>())
            {
                other.GetComponent<LiquidSpawner>().SpawnLiquid(color);
                Destroy(gameObject);
            }
        }
    }
    private void CheckIfPlayerHolding()
    {
        if(playerHoldingThis)
        {
            transform.rotation = transform.parent.parent.rotation;
            isOnGround = false; 
        }
    }
    private void GroundTimer()
    {
        if(isOnGround)
        {
            groundTimer += Time.deltaTime;
        }
        else
        {
            groundTimer = 0;
        }
    }
    private void DestroyIfOnGround()
    {
        if(groundTimer > maxGroundTime)
        {
            Destroy(gameObject);
        }
    }
}
