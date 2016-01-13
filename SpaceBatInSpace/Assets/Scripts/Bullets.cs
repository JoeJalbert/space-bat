using UnityEngine;
using System.Collections;

public class Bullets : MonoBehaviour {

    public float xSpeed;
    public float ySpeed;
    Vector2 shotSpeed;

    public int damage;

	void Start () {
        shotSpeed = new Vector2(xSpeed, ySpeed);

		Physics2D.IgnoreLayerCollision (8, 0, true);
	}

	void OnCollisionEnter2D(Collision2D c){
		if (c.gameObject.tag != "Player" && c.gameObject.layer != LayerMask.NameToLayer("Bullet")) {
			Debug.Log ("Bullet hit " + c.gameObject.name);
			Destroy(gameObject);
		}
	}
	
	void Update () {

        GetComponent<Rigidbody2D>().velocity = shotSpeed;

	}
}
