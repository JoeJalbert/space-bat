using UnityEngine;
using System.Collections;

public class PlayerShot : MonoBehaviour {

    public GameObject bullet;
    public GameObject shotSpot;

    public AudioClip shotSound;
    private AudioSource audioSource;

    bool canShoot = true;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update () {
        if (Input.GetKey(KeyCode.Space) && canShoot)
        {
            StartCoroutine(shotDelay());
        }
	}

    IEnumerator shotDelay()
    {
        canShoot = false;
        yield return new WaitForSeconds(.1f);

        audioSource.PlayOneShot(shotSound);

        GameObject tempBullet1;
        tempBullet1 = Instantiate(bullet, shotSpot.transform.position, Quaternion.identity) as GameObject;
        tempBullet1.GetComponent<Bullets>().xSpeed = 1;
        tempBullet1.GetComponent<Bullets>().ySpeed = 0;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            GameObject tempBullet2;
            tempBullet2 = Instantiate(bullet, shotSpot.transform.position, Quaternion.identity) as GameObject;
            tempBullet2.GetComponent<Bullets>().xSpeed = 1;
            tempBullet2.GetComponent<Bullets>().ySpeed = .1f;

            GameObject tempBullet3;
            tempBullet3 = Instantiate(bullet, shotSpot.transform.position, Quaternion.identity) as GameObject;
            tempBullet3.GetComponent<Bullets>().xSpeed = 1;
            tempBullet3.GetComponent<Bullets>().ySpeed = -.1f;
        }
        else
        {
            GameObject tempBullet2;
            tempBullet2 = Instantiate(bullet, shotSpot.transform.position, Quaternion.identity) as GameObject;
            tempBullet2.GetComponent<Bullets>().xSpeed = 1;
            tempBullet2.GetComponent<Bullets>().ySpeed = .4f;

            GameObject tempBullet3;
            tempBullet3 = Instantiate(bullet, shotSpot.transform.position, Quaternion.identity) as GameObject;
            tempBullet3.GetComponent<Bullets>().xSpeed = 1;
            tempBullet3.GetComponent<Bullets>().ySpeed = -.4f;
        }

        canShoot = true;
    }
}
