using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour {

	public float shotSpeed;
	
	public int damage;

	public Vector2 target;
	Vector3 tempTarget;
	
	void Start () {

		target = GameObject.FindWithTag ("Player").transform.position;

		tempTarget = new Vector3(target.x - transform.position.x, target.y - transform.position.y, 0);
	}
	
	void Update () { 


		transform.position += tempTarget.normalized * 0.01f;

		//transform.position = Vector2.MoveTowards (transform.position, target, shotSpeed);
		
		if (transform.position.x < -1.4)
		{
			Destroy(gameObject);
		}
	}

	void OnCollisionEnter(){

	}
}
