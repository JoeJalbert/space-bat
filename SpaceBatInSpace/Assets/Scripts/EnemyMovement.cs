using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

    Vector2 InitialPosition;
    Vector2 currentVelocity;

	void Start ()
    {
        InitialPosition = new Vector2(1.6f, Random.Range(-.65f, .65f));
        transform.position = InitialPosition;
        currentVelocity = new Vector2(-1, 0);
    }

    void Update ()
    {
        GetComponent<Rigidbody2D>().velocity = currentVelocity;

        if(transform.position.x < -1.4f)
        {
            Destroy(gameObject);
        }
	}

    void OnCollisionEnter2D(Collision2D c)
    {
        if(c.gameObject.tag == "Bullet")
        {
            if (c.gameObject.transform.position.y > 0)
            {
                currentVelocity = new Vector2(-1, 1);
            }
            else
            {
                currentVelocity = new Vector2(-1, -1);
            }
            //Destroy(gameObject);
        }
    }
}
