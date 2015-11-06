using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    public GameObject[] enemy;
    bool readyToSpawn = true;

    void Start () {
	
	}

    void Update () {

        if (readyToSpawn)
        {
            StartCoroutine(spawnEnemy());
        }

	}

    IEnumerator spawnEnemy()
    {
        readyToSpawn = false;
        yield return new WaitForSeconds(Random.Range(0, 5));
        Instantiate(enemy[(Random.Range(0, enemy.Length))], transform.position, Quaternion.identity);
        readyToSpawn = true;
    }
}
