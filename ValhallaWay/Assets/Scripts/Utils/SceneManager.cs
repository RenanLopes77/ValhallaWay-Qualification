using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class SceneSelector
{
	public Button button;
	public Utils.ScenesNames name;
}

public class SceneManager : MonoBehaviour {

	public SceneSelector[] sceneSelectors = new SceneSelector[0];

	void Start () {
		setSceneButtons();
	}

	public void setSceneButtons()
	{
		Array.ForEach (sceneSelectors, sceneSelector => {
			if (sceneSelector.name != Utils.ScenesNames.Null)
			{
				sceneSelector.button.onClick.AddListener (delegate () {
					UnityEngine.SceneManagement.SceneManager.LoadScene (Enum.GetName(typeof(Utils.ScenesNames), sceneSelector.name));
				});
			} else {
				Debug.LogError("Button without scene name");
			}
		});
	}
}
