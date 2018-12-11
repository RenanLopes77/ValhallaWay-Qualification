using UnityEngine;

public class EnemyController : MonoBehaviour
{
	public Transform [] nodes;
	public float speed = 5;
	private bool isHunter;
	private int curNode;
	public int HitsReceived = 0;
	public int HitsCanHandle = 3;

	private void Awake()
	{
		if (nodes.Length > 0)
		{
			isHunter = false;
		}
		else
		{
			isHunter = true;
		}
	}

	void Update () {
		if (!isHunter)
		{
			NodeMovement();			
		}
	}

	private void NodeMovement()
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

	private void OnTriggerStay2D(Collider2D other)
	{
		if (isHunter)
		{
			if (other.gameObject.CompareTag("Player"))
			{
				transform.position = Vector2.MoveTowards (transform.position, new Vector2(other.transform.position.x , transform.position.y), speed * Time.deltaTime);
			}
		}
	}
}