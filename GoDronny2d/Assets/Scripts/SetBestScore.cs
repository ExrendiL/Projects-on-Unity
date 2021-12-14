using UnityEngine;
using UnityEngine.UI;

public class SetBestScore : MonoBehaviour {

    private void Awake() {
        GetComponent<Text>().text = "Рекорд: " + PlayerPrefs.GetInt("score").ToString();
    }

}
