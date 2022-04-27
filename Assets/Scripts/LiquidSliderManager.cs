using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiquidSliderManager : MonoBehaviour
{
    [Header("Sliders")]
    [SerializeField] private Slider purpleSlider;
    [SerializeField] private Slider greenSlider;
    [SerializeField] private Slider orangeSlider;
    private GameManager gameManager;
    private void Start() 
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    
    private void Update()
    {
        CheckWinCondition();
    }

    public Slider GetSlider(string color)
    {
        if(color == "Purple")
        {
            return purpleSlider;
        }
        if(color == "Green")
        {
            return greenSlider;
        }
        if(color == "Orange")
        {
            return orangeSlider;
        }
        else
        {
            return null;
        }
    }
    public void UpdateSlider(Slider slider,bool check)
    {
        if(slider != null)
        {
            slider.GetComponent<LiquidSlider>().SetNextValue(check);
        }
    }

    private bool IsSliderFull(Slider slider)
    {
        return slider.value == slider.maxValue;
    }
    
    private void CheckWinCondition()
    {
        if(IsSliderFull(purpleSlider) && IsSliderFull(greenSlider) && IsSliderFull(orangeSlider))
        {
            gameManager.Win();
        }
    }
    
}


