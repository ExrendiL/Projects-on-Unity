using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartShadow : MonoBehaviour
{
    [SerializeField] private GameObject shadow;
    private void Start()
    {
        if (shadow.active)
        { 
            StartCoroutine(SetActive()); 
        }
        
    }

    private IEnumerator SetActive()
    {
        if (shadow.active)
        {
            shadow.SetActive(false);
            Debug.Log("W");
            yield return new WaitForSeconds(10f);
        }
           
        
       
    }
}
