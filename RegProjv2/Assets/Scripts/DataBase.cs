using UnityEngine;
using System.Collections;

public class DataBase : MonoBehaviour {

    private string[] users;

    private void Start() {
        StartCoroutine(getData());
    }

    IEnumerator getData() {
        WWW items = new WWW("http://localhost/");
        yield return items;
        string data = items.text;

        data = data.Remove(data.Length - 1);
        users = data.Split(';');

        Debug.Log(getValue(users[1], "Name:"));
    }

    string getValue(string data, string index) {
        string val = data.Substring(data.IndexOf(index) + index.Length);
        if(val.Contains("|"))
            val = val.Remove(val.IndexOf("|"));

        return val;
    }

}
