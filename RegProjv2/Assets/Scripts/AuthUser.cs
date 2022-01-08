using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AuthUser : MonoBehaviour {

    public InputField login, pass;

    public void ButtonClick() {
        if (login.text != "" && pass.text != "")
            StartCoroutine(authUser(login.text, pass.text));
    }

    IEnumerator authUser(string login, string pass) {
        WWWForm form = new WWWForm();
        form.AddField("login", login);
        form.AddField("pass", pass);

        WWW www = new WWW("http://localhost/auth.php", form);
        yield return www;
        string data = www.text;
        if(data == "Done") {
            Application.LoadLevel("FirstScene");
        } else {
            Debug.Log("Ошибка: " + data);
        }
    }

}
