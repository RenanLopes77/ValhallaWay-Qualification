using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour {

    public Button MainMenu;

    void Start() {
        MainMenu.onClick.AddListener(delegate () {
            SceneManager.LoadScene("Main_Menu");
        });
    }
}