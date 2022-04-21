using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControls : MonoBehaviour
{
    private PlayerController player;
    [Header("Throw")]
    [SerializeField] private float throwSpeed = 10f;
    [SerializeField] public float verticalPower = 10f;
    [Header("Ball Related")]
    [SerializeField] public GameObject currentBall;
    [SerializeField] private GameObject ballHoldPoint;
    [SerializeField] public GameObject nearbyBall;
    [SerializeField] public bool canPickUp;
    [SerializeField] public bool hasBall;
    
    void Start()
    {
        player = GetComponent<PlayerController>();
    }
    void Update()
    {
        BallControl();
    }
    void Throw()
    {
        if(Input.GetMouseButtonDown(0))
        {
            currentBall.GetComponent<Rigidbody>().isKinematic = false;
            currentBall.GetComponent<Ball>().playerHoldingThis = false;
            currentBall.transform.parent = null;
            currentBall.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * throwSpeed,ForceMode.VelocityChange);
            currentBall.GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * verticalPower,ForceMode.VelocityChange);
            hasBall = false;
            currentBall = null;
        }
    }
    void PickUp()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            currentBall = GetNearbyBall();
            currentBall.GetComponent<Ball>().playerHoldingThis = true;
            hasBall = true;
            currentBall.GetComponent<Rigidbody>().isKinematic = true;
            currentBall.transform.position = ballHoldPoint.transform.position;
            currentBall.transform.parent = ballHoldPoint.transform;
        }
    }
    public void BallControl()
    {
        if(hasBall)
        {
            Throw();
        }
        if(canPickUp && !hasBall && currentBall == null)
        {
            PickUp();
        }
    }
    public GameObject GetNearbyBall()
    {
        return nearbyBall != null ? nearbyBall : null;
    }
}
