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
    [Header("SlidersMaxValues")]
    [SerializeField] private float orangeSliderMaxValue;
    [SerializeField] private float greenSliderMaxValue;
    [SerializeField] private float purpleSliderMaxValue;
    
    private void Start()
    {
        SetSlidersMaxValue();
    }
    private void SetSlidersMaxValue()
    {
        purpleSlider.maxValue = purpleSliderMaxValue;
        orangeSlider.maxValue = orangeSliderMaxValue;
        greenSlider.maxValue = greenSliderMaxValue;
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
    
    
    
    

    
    













}


