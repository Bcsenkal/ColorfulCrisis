using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MaterialProvider : MonoBehaviour
{
    [SerializeField] List<Material> materials;
    
    public Material GetMaterial(string str)
    {
        var material = materials.Where(m => m.name == str).SingleOrDefault();
        return material;
    }
}
