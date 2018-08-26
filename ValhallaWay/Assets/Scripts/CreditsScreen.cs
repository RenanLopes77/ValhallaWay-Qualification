using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditsScreen : MonoBehaviour {
    public Button BackButton;

    void Start() {
        BackButton.onClick.AddListener(delegate () {
            SceneManager.LoadScene("Main_Menu");
        });
    }
}
