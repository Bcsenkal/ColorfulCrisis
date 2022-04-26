using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private CapsuleCollider col;
    private BallControls ballControls;
    [SerializeField] MaterialProvider materialProvider;
    [Header("Movement")]
    [SerializeField] public float currentSpeed = 10f;
    [SerializeField] public float defaultSpeed = 15f;
    [SerializeField] public float infectionSpeed = 10f;
    [Header("Bounds")]
    [SerializeField] private float xBound = 0f;
    [SerializeField] private float zBound = 0f;
    [Header("InfectionRelated")]
    [SerializeField] public bool canPickUp;
    [SerializeField] public bool hasBall;
    [SerializeField] public bool hasSlowedDownInfection;
    [SerializeField] public bool hasPickUpInfection;
    [SerializeField] public bool hasSpawnInfection;
    
    private MousePositionProvider mousePos;
    
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
        ballControls = GetComponent<BallControls>();
        mousePos = FindObjectOfType<MousePositionProvider>();
        currentSpeed = defaultSpeed;
    }

    void Update()
    {
        if(!FindObjectOfType<GameManager>().gameIsPaused)
        {
            Move();
            ConstraintMovement();
            BallControl();
            InfectionCheck();
        }
    }

    void Move()
    {
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        var verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3(horizontalInput,0.0f,verticalInput);
        transform.LookAt(new Vector3(mousePos.pointToLook.x,transform.position.y,mousePos.pointToLook.z));
        if(movement == Vector3.zero)
        {
            playerRb.velocity = Vector3.zero;
        }
        transform.Translate(movement * currentSpeed * Time.deltaTime,Space.World);
    }

    void ConstraintMovement()
    {
        if(transform.position.z < -zBound)
        {
            transform.position = new Vector3(transform.position.x,transform.position.y,-zBound);
        }
        if(transform.position.z > zBound - 5.5f)
        {
            transform.position = new Vector3(transform.position.x,transform.position.y,zBound - 5.5f);
        }
        if(transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound,transform.position.y,transform.position.z);
        }
        if(transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound,transform.position.y,transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Ball" && !hasPickUpInfection)
        {
            canPickUp = true;
            ballControls.nearbyBall = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        canPickUp = false;
    }

    public void BallControl()
    {
        if(hasBall)
        {
            ballControls.Throw();
        }
        if(canPickUp && !hasBall && ballControls.currentBall == null)
        {
            ballControls.PickUp();
        }
    }
    
    private void InfectionCheck()
    {
        if(!hasPickUpInfection && !hasSlowedDownInfection && !hasSpawnInfection)
        {
            GetComponent<MeshRenderer>().material = materialProvider.GetMaterial("Player");
        }
    }
}
