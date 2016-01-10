using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D c) 
	{
		if (c.gameObject.tag == "Enemy") {
			Destroy(c.gameObject);
		}
	}
}
