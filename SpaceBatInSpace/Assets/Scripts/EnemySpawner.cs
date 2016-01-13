using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    public GameObject[] enemy;
    bool readyToSpawn = true;

	public float frequency;

    void Start () {
	
	}

    void Update () {

        if (readyToSpawn)
        {
            StartCoroutine(spawnEnemy());
        }

		Vector2 tempPos = transform.position;
		tempPos.x = Random.Range (-2.5f, 2.5f);
		transform.position = tempPos;

	}

    IEnumerator spawnEnemy()
    {
        readyToSpawn = false;
        yield return new WaitForSeconds(Random.Range(0f, frequency));
        Instantiate(enemy[(Random.Range(0, enemy.Length))], transform.position, Quaternion.identity);
        readyToSpawn = true;
    }
}
