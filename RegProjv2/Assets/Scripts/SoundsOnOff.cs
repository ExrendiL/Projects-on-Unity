using UnityEngine;
using UnityEngine.UI;

public class SoundsOnOff : MonoBehaviour {

    private Toggle toggle;
    public AudioListener audio;

    private void Start() {
        toggle = gameObject.GetComponent<Toggle>();
    }

    public void setSounds() {
        if(toggle.isOn) { // Галочка была поставлена
            gameObject.transform.GetChild(1).GetComponent<Text>().text = "Выключить звук";
            audio.enabled = true;
        } else { // Галочка была отменена
            gameObject.transform.GetChild(1).GetComponent<Text>().text = "Включить звук";
            audio.enabled = false;
        }
    }

}
