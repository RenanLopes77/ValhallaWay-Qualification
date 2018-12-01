using UnityEngine;

public class EnemyController : MonoBehaviour
{
	public Transform [] nodes;
	public float speed = 5;
	private int curNode;

	void Update () {
		EnemyMove();
	}

	public void EnemyMove()
	{
		transform.position = Vector2.MoveTowards (transform.position, nodes [curNode].position, speed * Time.deltaTime);
		if (Vector2.Distance(transform.position, nodes[curNode].position) < 0.2f){
			transform.position = nodes [curNode].position;
			curNode++;
			if(curNode >= nodes.Length){
				curNode = 0;
			}
		}
	}
}