using UnityEngine;
using UnityEngine.UI;

public class CreateUser : MonoBehaviour {

    public InputField name, login, pass;

    public void ButtonClick() {
        if(name.text != "" && login.text != "" && pass.text != "")
            createUser(name.text, login.text, pass.text);
    }

    void createUser(string name, string login, string pass) {
        this.name.text = "";
        this.login.text = "";
        this.pass.text = "";

        WWWForm form = new WWWForm();
        form.AddField("name", name);
        form.AddField("login", login);
        form.AddField("pass", pass);

        WWW www = new WWW("http://localhost/reg.php", form);
    }

}
