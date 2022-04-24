using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBehaviour : MonoBehaviour
{
    public string boxColor;
    private LiquidSpawner liquidSpawner;
    private LiquidSliderManager liquidSliderManager;
    BoxManager boxManager;

    void Awake()
    {
        boxColor = gameObject.name.Replace("Box","");
        liquidSpawner = GetComponentInChildren<LiquidSpawner>();
        liquidSliderManager = FindObjectOfType<LiquidSliderManager>();
        boxManager = FindObjectOfType<BoxManager>();
    }
    public void ColorMatchCheck(string liquidColor)
    {
        if(liquidSpawner.currentLiquid != null)
        {
            bool colormatched;
            if(liquidColor != "Red" && liquidColor != "Blue" && liquidColor != "Yellow")
            {
                if(liquidColor == boxColor)
                {
                    colormatched = true;
                    boxManager.CorrectMatch(gameObject);
                    liquidSliderManager.UpdateSlider(liquidSliderManager.GetSlider(boxColor),colormatched);
                    
                }
                if(liquidColor != boxColor)
                {
                    colormatched = false;
                    boxManager.IncorrectMatch(gameObject);
                    liquidSliderManager.UpdateSlider(liquidSliderManager.GetSlider(boxColor),colormatched);
                }
            }
        }
    }
    
    
}
