using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win2Scr : MonoBehaviour
{
    public Transform box;
    public CanvasGroup bg;


    private void OnEnable()
    {
        bg.alpha = 0;
        bg.LeanAlpha(1, 0.5f);

        box.localPosition = new Vector2(-Screen.width, -20);
        box.LeanMoveLocalX(180, 0.5f).setEaseOutExpo().delay = 0.1f;
    }

    public void CloseDialoge() 
    {
        bg.LeanAlpha(0, 0.5f);
        box.LeanMoveLocalX(-Screen.width, 0.5f).setEaseInExpo().setOnComplete(OnCompl);
    }

    void OnCompl() 
    {
        gameObject.SetActive(false);
    }

}
