using UnityEngine;

public class WeaponController : MonoBehaviour {
	private void OnTriggerEnter2D(Collider2D other) {
		if (other.transform.CompareTag("Enemy")) 
		{
			Destroy(other.gameObject);
		}
	}
}
