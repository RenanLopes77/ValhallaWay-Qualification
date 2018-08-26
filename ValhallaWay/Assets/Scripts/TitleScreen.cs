using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour {

    public Button NewGameButton;
    public Button SettingsButton;
    public Button CreditsButton;

    void Start() {
        NewGameButton.onClick.AddListener(delegate () {
            SceneManager.LoadScene("1-1");
        });

        CreditsButton.onClick.AddListener(delegate () {
            SceneManager.LoadScene("Credits");
        });

        SettingsButton.onClick.AddListener(delegate () {
            //show settings panel
            Debug.Log("Mostra painel de configurações");
        });
    }



}
