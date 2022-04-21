using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxManager : MonoBehaviour
{
    public void CorrectMatch(GameObject gameObject)
    {
        StartCoroutine(CorrectMatchCoroutine(gameObject));
    }
    public void IncorrectMatch(GameObject gameObject)
    {
        StartCoroutine(IncorrectMatchCoroutine(gameObject));
    }
    public IEnumerator CorrectMatchCoroutine(GameObject box)
    {
        yield return new WaitForSeconds(1);
        Destroy(box.GetComponentInChildren<LiquidSpawner>().currentLiquid);
    }
    public IEnumerator IncorrectMatchCoroutine(GameObject box)
    {
        yield return new WaitForSeconds(1);
        Destroy(box.GetComponentInChildren<LiquidSpawner>().currentLiquid);
        box.SetActive(false);
        yield return new WaitForSeconds(3);
        box.SetActive(true);
    }
}
