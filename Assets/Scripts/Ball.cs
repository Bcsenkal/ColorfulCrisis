using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public bool isOnGround;
    public bool playerHoldingThis;
    private Rigidbody ballRb;
    [SerializeField] private float removalDelay;
    [SerializeField] public string color;
    
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
    }
    
    private void OnCollisionStay(Collision other) 
    {
        if(other.gameObject.tag == "Ground" && ballRb.velocity == Vector3.zero)
        {
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
}
