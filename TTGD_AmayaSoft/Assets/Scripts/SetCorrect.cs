using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCorrect : MonoBehaviour
{
    [SerializeField] private GameObject A;
    [SerializeField] private GameObject F;
    [SerializeField] private GameObject two;
    public void SetCorrectAnswer()
    {
        A.GetComponent<NoCorrect>().enabled = false;
    }

    public void SetCorrectAnswer1()
    {
       
      
        A.GetComponent<NoCorrect>().enabled = true;
        Destroy(A.GetComponent<CorrectAnimation>());
        F.GetComponent<NoCorrect>().enabled = false;
    }
    public void SetCorrectAnswer2()
    {
        Destroy(A.GetComponent<CorrectAnimation>());
        two.GetComponent<NoCorrect>().enabled = false;
    }
}
