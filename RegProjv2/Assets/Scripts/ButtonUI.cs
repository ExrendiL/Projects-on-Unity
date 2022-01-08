using UnityEngine;
using UnityEngine.UI;

public class ButtonUI : MonoBehaviour {

    public RawImage img;
    public Texture image;

    public void setNewImage() {
        img.texture = image;
    }

    public void setNewText(string words) {
        gameObject.GetComponentInChildren<Text>().text = words;

        Destroy(gameObject.transform.GetChild(0));
    }

    public void DisableButton() {
        gameObject.SetActive(false);
    }

}
