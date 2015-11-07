using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    public float speed;
    public float maxSpeed;

    Vector2 currentVelocity;
    bool canMove = true;

	void Update () {

        GetComponent<Rigidbody2D>().velocity = currentVelocity;

        if (canMove)
        {
            transform.position = new Vector2(Mathf.Clamp(transform.position.x, -1.2f, 1.2f), Mathf.Clamp(transform.position.y, -.7f, .7f));

            currentVelocity = new Vector2(Mathf.Clamp(currentVelocity.x, -maxSpeed, maxSpeed), Mathf.Clamp(currentVelocity.y, -maxSpeed, maxSpeed));

            // Move Up
            if (Input.GetKey(KeyCode.W))
            {
                currentVelocity += new Vector2(0, speed);
            }
            // Move Down
            else if (Input.GetKey(KeyCode.S))
            {
                currentVelocity += new Vector2(0, -speed);
            }
            else
            {
                currentVelocity = Vector2.MoveTowards(currentVelocity, new Vector2(currentVelocity.x, 0), speed);
            }

            // Move Left
            if (Input.GetKey(KeyCode.A))
            {
                currentVelocity += new Vector2(-speed, 0);
            }
            // Move Right
            else if (Input.GetKey(KeyCode.D))
            {
                currentVelocity += new Vector2(speed, 0);
            }
            else
            {
                currentVelocity = Vector2.MoveTowards(currentVelocity, new Vector2(0, currentVelocity.y), speed);
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = .03f;
                maxSpeed = .25f;
            }
            else
            {
                speed = .1f;
                maxSpeed = 1;
            }

            if (!Input.anyKey)
            {
                currentVelocity = Vector2.MoveTowards(currentVelocity, new Vector2(0, 0), speed);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if(c.gameObject.tag == "Enemy")
        {
            currentVelocity = new Vector2(0, -1);
            canMove = false;
        }
    }
}
