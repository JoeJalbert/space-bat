using UnityEngine;
using System.Collections;

public class PlayerShot : MonoBehaviour {

    public GameObject bullet;
    public GameObject shotSpot;

    void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Object tempBullet;
            tempBullet = Instantiate(bullet, shotSpot.transform.position, Quaternion.identity);
            //.GetComponent<>();
        }
	}
}
