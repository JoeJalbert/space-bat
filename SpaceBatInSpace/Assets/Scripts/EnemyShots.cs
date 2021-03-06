﻿using UnityEngine;
using System.Collections;

public class EnemyShots : MonoBehaviour {

	public GameObject enemyShot;
	public GameObject shotPoint;
	
	public float shotSpeed;

	bool canShoot = true;

	void Start () {
		if (canShoot)
		{
			StartCoroutine(shotDelay());
		}
	}
	
	IEnumerator shotDelay()
	{
		canShoot = false;
		yield return new WaitForSeconds(Random.Range(0,2));

		GameObject tempBullet;
		tempBullet = Instantiate(enemyShot, shotPoint.transform.position, Quaternion.identity) as GameObject;
		tempBullet.GetComponent<EnemyBullet> ().speedMultiplier = shotSpeed;
		tempBullet.transform.parent = gameObject.transform.parent;

		canShoot = true;
	}
}
