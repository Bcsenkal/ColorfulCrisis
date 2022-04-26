using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiquidSlider : MonoBehaviour
{
    [SerializeField] public float nextValue;
    [SerializeField] public float fillingSpeed;
    [SerializeField] private float fillingValue;
    private GameManager gameManager;
    private Slider slider;
    private void Start() 
    {
        slider = GetComponent<Slider>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update() 
    {
        if(!gameManager.gameIsPaused)
        {
            UpdateSliderValue(nextValue,fillingSpeed);
            ConstraintNextValue();
        }
    }

    private void UpdateSliderValue(float nextvalue,float speed)
    {
        slider.value = Mathf.Lerp(slider.value,nextvalue,speed * Time.deltaTime);
    }

    public void SetNextValue(bool check)
    {
        if(check)
        {
            nextValue += fillingValue;
        }
        else if(!check)
        {
            nextValue -= fillingValue * 1.5f;
        }
    }

    private void ConstraintNextValue()
    {
        if(nextValue > slider.maxValue)
        {
            nextValue = slider.maxValue;
        }
        else if(nextValue < slider.minValue)
        {
            nextValue = slider.minValue;
        }
    }
}
