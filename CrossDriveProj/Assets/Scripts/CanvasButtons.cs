using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasButtons : MonoBehaviour {
    
    public Sprite btn, btnPressed;
    private Image image;

    void Start() {
        image = GetComponent<Image>();
    }

    public void PlayGame() {
        if(PlayerPrefs.GetString("First Game") == "No")
            StartCoroutine(LoadScene("Game"));
        else 
            StartCoroutine(LoadScene("Study"));
    }

    public void RestartGame() {
        StartCoroutine(LoadScene("Game"));
    }
    
    public void SetPressedButton() {
        image.sprite = btnPressed;
        transform.GetChild(0).localPosition -= new Vector3(0, 5f, 0);
    }
    
    public void SetDefaultButton() {
        image.sprite = btn;
        transform.GetChild(0).localPosition += new Vector3(0, 5f, 0);
    }

    IEnumerator LoadScene(string name) {
        float fadeTime = Camera.main.GetComponent<Fading>().Fade(1f);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(name);
    }

}
