using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool gameIsActive = false;
    [SerializeField] private GameObject infoScreen;

    public void StartGame()
    {
        gameIsActive = true;
        infoScreen.SetActive(false);
    }
}
