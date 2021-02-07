using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve : MonoBehaviour
{

    [SerializeField] Material myMaterial;

    private bool isDissolving = true;

    private float dissolveAmount = 0f;
    [SerializeField] float dissolveSpeed = 1f;

    private void Update()
    {
        if (isDissolving)
        {
            dissolveAmount = Mathf.Clamp01(dissolveAmount + dissolveSpeed * Time.deltaTime);
            myMaterial.SetFloat("_Amount", dissolveAmount);
        }
        else
        {
            dissolveAmount = Mathf.Clamp01(dissolveAmount - dissolveSpeed * Time.deltaTime);
            myMaterial.SetFloat("_Amount", dissolveAmount);
        }
    }

   
    public void DissolveIn()
    {
        isDissolving = true;
    }
    public void DissolveOut()
    {
        isDissolving = false;
    }
}
