using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasButtons : MonoBehaviour
{
    [SerializeField] private GameObject menu;

    private void Update()
    {
        if (GameObject.Find("Player") != null)
        {
            menu.SetActive(false);
        }
    }
    public void StartGame()
    {
     
        SceneManager.LoadScene("Game");
    }


    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Exit()
    {
        Application.Quit();
    }

}
