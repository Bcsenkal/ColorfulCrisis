using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBehaviour : MonoBehaviour
{
    public string boxColor;
    private LiquidSpawner liquidSpawner;
    BoxManager boxManager;

    void Awake()
    {
        boxColor = gameObject.name.Replace("Box","");
        liquidSpawner = GetComponentInChildren<LiquidSpawner>();
        boxManager = FindObjectOfType<BoxManager>();
    }
    public void ColorMatchCheck(string liquidColor)
    {
        if(liquidSpawner.currentLiquid != null)
        {
            if(liquidColor != "Red" && liquidColor != "Blue" && liquidColor != "Yellow")
            {
                if(liquidColor == boxColor)
                {
                    boxManager.CorrectMatch(gameObject);
                }
                if(liquidColor != boxColor)
                {
                    boxManager.IncorrectMatch(gameObject);
                }
            }
        }
    }
    
    
}
