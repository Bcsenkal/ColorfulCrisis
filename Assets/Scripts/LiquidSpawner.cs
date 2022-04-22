using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LiquidSpawner : MonoBehaviour
{
    [SerializeField] private GameObject liquidPrefab;
    [SerializeField] public GameObject currentLiquid;
    [SerializeField] public string currentLiquidColor;
    [SerializeField] private MaterialProvider materialProvider;

    public void SpawnLiquid(string color)
    {
        if(currentLiquid == null)
        {
            SetLiquidColor(materialProvider.GetMaterial(color));
            currentLiquid = Instantiate(liquidPrefab,transform.parent.position,liquidPrefab.transform.rotation);
            currentLiquid.transform.parent = gameObject.transform.parent;
            currentLiquidColor = color;
        }
        else
        {
            DecideNextColor(currentLiquidColor,color);
        }
        GetComponentInParent<BoxBehaviour>().ColorMatchCheck(currentLiquidColor);
    }

    public void SetLiquidColor(Material material)
    {
        liquidPrefab.GetComponent<MeshRenderer>().material = material;
    }

    public void ChangeLiquidColor(string color)
    {
        currentLiquid.GetComponent<MeshRenderer>().material = materialProvider.GetMaterial(color);
        currentLiquidColor = color;
    }
    
    public void DecideNextColor(string currentcolor, string nextcolor)
    {
        if(currentcolor == "Red")
        {
            if(nextcolor == "Blue")
            {
                ChangeLiquidColor("Purple");
            }
            if(nextcolor == "Yellow")
            {
                ChangeLiquidColor("Orange");
            }
        }
        if(currentcolor == "Yellow")
        {
            if(nextcolor == "Red")
            {
                ChangeLiquidColor("Orange");
            }
            if(nextcolor == "Blue")
            {
                ChangeLiquidColor("Green");
            }
        }
        if(currentcolor == "Blue")
        {
            if(nextcolor == "Red")
            {
                ChangeLiquidColor("Purple");
            }
            if(nextcolor == "Yellow")
            {
                ChangeLiquidColor("Green");
            }
        }
    }
}
