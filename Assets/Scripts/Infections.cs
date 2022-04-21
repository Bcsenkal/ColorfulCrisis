using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infections : MonoBehaviour
{
    private PlayerController player;
    [SerializeField] private float slowDownValue;
    void Start()
    {
        player = GetComponent<PlayerController>();
    }
    
}
