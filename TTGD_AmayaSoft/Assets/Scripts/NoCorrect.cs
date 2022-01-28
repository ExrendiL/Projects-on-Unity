using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoCorrect : MonoBehaviour
{
    public void NoCorrectAnimation()
    {
        Animation anim = GetComponent<Animation>();
        anim.Play("NotCorrect");
    }

}
