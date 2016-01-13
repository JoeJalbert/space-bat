using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour {

	public int damage;

	public Vector2 target;
	Vector3 tempTarget;

	public float speedMultiplier;
	
	void Start () {

		target = GameObject.FindWithTag ("Player").transform.position;

		tempTarget = new Vector3(target.x - transform.position.x, target.y - transform.position.y, 0);
	}
	
	void Update () { 

		transform.position += tempTarget.normalized * speedMultiplier;

	}

	void OnCollisionEnter2D(Collision2D c)
	{
		if (c.gameObject.layer == LayerMask.NameToLayer ("Wall")) {
			Destroy(gameObject);
		}
	}
}
