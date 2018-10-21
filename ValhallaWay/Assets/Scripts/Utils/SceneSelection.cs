using System;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[Serializable]
public class Teste
{
	public Button button;
	public Utils.Scenes name;
}

public class SceneSelection : MonoBehaviour {

	public Teste[] scenes = new Teste[0];

	void Start () {
		Array.ForEach (scenes, scene => {
			if (scene.name != Utils.Scenes.Null)
			{
				scene.button.onClick.AddListener (delegate () {
					SceneManager.LoadScene (Enum.GetName(typeof(Utils.Scenes), scene.name));
				});
			} else {
				Debug.LogError("Button without scene name");
			}
		});
	}
}
