using UnityEngine;

enum Cameras {
    MenuCamera = 0,
    GameCamera = 1,
    JointCamera = 2
}

public class UserInterface : MonoBehaviour {

    public Camera[] cams;

    private void Start() {
        changeCamera(Cameras.GameCamera);
    }

    private void OnGUI() {
        //if (GUILayout.Button("Нажми на меня")) {
        //    Debug.Log("Вы нажали на кнопку");
        //}

        GUIStyle styleBox = new GUIStyle(GUI.skin.box) {
            fontSize = 30
        };

        GUI.Box(new Rect(10, 10, 350, 370), "Панель меню", styleBox);

       // text = GUI.TextArea(new Rect(Screen.width - 250, 30, 200, 40), text, 25);

        GUIStyle styleBtn = new GUIStyle(GUI.skin.button) {
            fontSize = 25
        };

        if (GUI.Button(new Rect(20, 70, 310, 70), "Камера #1", styleBtn)) {
            changeCamera(Cameras.MenuCamera);
        }

        if (GUI.Button(new Rect(20, 160, 310, 70), "Камера #2", styleBtn)) {
            changeCamera(Cameras.GameCamera);
        }

        if (GUI.Button(new Rect(20, 250, 310, 70), "Камера #3", styleBtn)) {
            changeCamera(Cameras.JointCamera);
        }
    }

    void changeCamera(Cameras camera) {
        for(int i = 0; i < cams.Length; i++) {
            if(i == (int)camera)
                cams[i].enabled = true;
            else
                cams[i].enabled = false;
        }
    }

}
