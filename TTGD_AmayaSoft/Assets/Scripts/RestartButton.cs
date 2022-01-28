using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour {


    public void RestartGame()
    {
        SceneManager.LoadScene("MainScene");
    }
  
}
