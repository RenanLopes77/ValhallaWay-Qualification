using UnityEngine;

public class EndAction : MonoBehaviour {
	private void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene ("Thanks");
		}
	}
}
