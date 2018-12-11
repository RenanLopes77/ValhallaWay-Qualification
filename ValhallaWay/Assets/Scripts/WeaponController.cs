using UnityEngine;

public class WeaponController : MonoBehaviour {
	private void OnTriggerEnter2D(Collider2D other) {
		if (other.transform.CompareTag("Enemy")) 
		{
			Destroy(other.gameObject);
		}
		else if (other.transform.CompareTag("HunterEnemy"))
		{
			other.GetComponent<EnemyController>().HitsReceived += 1;
			if (other.GetComponent<EnemyController>().HitsReceived >=
			    other.GetComponent<EnemyController>().HitsCanHandle)
			{
				Destroy(other.gameObject);
			}
		}
	}
}
