using UnityEngine;
using System.Collections;

public class Bullets : MonoBehaviour {

    public float maxSpeed;
    Vector2 shotSpeed;

	void Start () {
        shotSpeed = new Vector2(maxSpeed, 0);
	}
	
	void Update () {

        GetComponent<Rigidbody2D>().velocity = shotSpeed;

        if (transform.position.x > 1.4)
        {
            Destroy(gameObject);
        }
	}
}
