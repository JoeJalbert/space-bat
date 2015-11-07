using UnityEngine;
using System.Collections;

public class PlayerShot : MonoBehaviour {

    public GameObject bullet;
    public GameObject shotSpot;

    bool canShoot = true;

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
        Object tempBullet;
        tempBullet = Instantiate(bullet, shotSpot.transform.position, Quaternion.identity);
        canShoot = true;
    }
}
