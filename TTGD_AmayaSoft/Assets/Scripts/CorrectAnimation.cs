using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectAnimation : MonoBehaviour
{
    [SerializeField] private GameObject next_btn;
    [SerializeField] private GameObject next_btn1;
    public void Correct_Animation()
    {
        Animation anim = GetComponent<Animation>();
        anim.Play("Correct");
        next_btn.SetActive(true);


    }

        public void Correct_Animation1()
    {
        Animation anim = GetComponent<Animation>();
        anim.Play("Correct");
        next_btn1.SetActive(true);


    }
}
