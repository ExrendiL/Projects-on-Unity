using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasButtons : MonoBehaviour
{
    public Sprite btn, btnPressed;
    private Image image;

    void Start()
    {
        image = GetComponent<Image>();
    }

    public void SetPressedButton()
    {
        image.sprite = btnPressed;
        transform.GetChild(0).localPosition -= new Vector3(0, 5f, 0);
    }

    public void SetDefaultButton()
    {
        image.sprite = btn;
        transform.GetChild(0).localPosition += new Vector3(0, 5f, 0);
    }
    public void EndGame()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        Application.LoadLevel("Game");
    }
    public void Back()
    {
        Application.LoadLevel("Menu");
    }

}
