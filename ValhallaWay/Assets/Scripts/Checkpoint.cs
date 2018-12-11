using UnityEngine;

public class Checkpoint : MonoBehaviour
{
	public SpriteRenderer Flag;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			other.GetComponent<PlayerController>().LastCheckpoint = gameObject;
			Flag.enabled = true;
		}
	}
}
