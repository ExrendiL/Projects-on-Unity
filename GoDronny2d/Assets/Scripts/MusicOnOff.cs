using UnityEngine;
using UnityEngine.UI;

public class MusicOnOff : MonoBehaviour {

    public AudioListener audio;
    public Sprite musicOn, musicOff;
    private Image button;

    private void Awake() {
        button = GetComponent<Image>();

        if (PlayerPrefs.GetString("music") == "off") {
            button.sprite = musicOff;
            audio.enabled = false;
        }
    }

    public void setMusic() {
        audio.enabled = !audio.enabled;

        if(audio.enabled) { // Музыка включена
            button.sprite = musicOn;
            PlayerPrefs.SetString("music", "on");
        } else {
            button.sprite = musicOff;
            PlayerPrefs.SetString("music", "off");
        }
    }

}
