using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

    public int health;
	
    Vector2 InitialPosition;
    Vector2 currentVelocity;

    public AudioClip deathSound;
    private AudioSource audioSource;

	public Vector2 speed;
	
	void Start ()
    {
        //InitialPosition = new Vector2(1.6f, Random.Range(-.65f, .65f));
        //transform.position = InitialPosition;
        currentVelocity = speed;

        audioSource = GetComponent<AudioSource>();
    }

    void Update ()
    {
        GetComponent<Rigidbody2D>().velocity = currentVelocity;

		/*
        if(transform.position.x < -1.4f)
        {
            Destroy(gameObject);
        }
        */
	}

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Bullet" && health > 0) {
			health -= c.gameObject.GetComponent<Bullets> ().damage;

			if (health <= 0) {
				//GetComponent<Rigidbody2D>().isKinematic = false;
				//GetComponent<BoxCollider2D>().enabled = false;

				audioSource.PlayOneShot (deathSound);

				if (c.gameObject.transform.position.x < 0) {
					currentVelocity = new Vector2 (-5, 5);
				} else {
					currentVelocity = new Vector2 (5, 5);
				}
				//Destroy(gameObject);
			}

			//Destroy(c.gameObject);
		} else {
			Physics2D.IgnoreCollision(GetComponent<Collider2D>(), c.collider, true);
		}

		if (c.gameObject.layer == LayerMask.NameToLayer ("Wall") || c.gameObject.layer == LayerMask.NameToLayer("Side")) {
			Debug.Log ("It hit");
			Destroy (gameObject);
		}
    }
}
