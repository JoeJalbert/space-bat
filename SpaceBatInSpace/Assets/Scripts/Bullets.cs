using UnityEngine;
using System.Collections;

public class Bullets : MonoBehaviour {

    public float xSpeed;
    public float ySpeed;
    Vector2 shotSpeed;

    public int damage;

	void Start () {
        shotSpeed = new Vector2(xSpeed, ySpeed);
	}
	
	void Update () {

        GetComponent<Rigidbody2D>().velocity = shotSpeed;

	}
}
