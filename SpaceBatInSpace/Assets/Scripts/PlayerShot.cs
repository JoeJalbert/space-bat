using UnityEngine;
using System.Collections;

public class PlayerShot : MonoBehaviour {

    public GameObject bullet;
    public GameObject shotSpot;

    public AudioClip shotSound;
    private AudioSource audioSource;

    private int shotDamage;
    private int shotSpread;
    private float rateOfFire;

    bool canShoot = true;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        shotDamage = GetComponent<PlayerStats>().shotDamage;
        shotSpread = GetComponent<PlayerStats>().shotSpread;
        rateOfFire = GetComponent<PlayerStats>().rateOfFire;

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

        audioSource.PlayOneShot(shotSound);

        GameObject tempBullet1;
        tempBullet1 = Instantiate(bullet, shotSpot.transform.position, Quaternion.identity) as GameObject;
        tempBullet1.GetComponent<Bullets>().xSpeed = 0;
        tempBullet1.GetComponent<Bullets>().ySpeed = 1;
        tempBullet1.GetComponent<Bullets>().damage = shotDamage;
        
        /*
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
        */

        yield return new WaitForSeconds(rateOfFire);
        canShoot = true;
    }
}
