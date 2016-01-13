using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MapStats : MonoBehaviour {

	public float maxTravelDistance;
	public float currentTravelDistance;
	
	public Text staminaText;

	public GameObject battleContainer;
	public GameObject mapScene;

	void Start () {
		maxTravelDistance = PlayerPrefs.GetFloat ("maxTravelDistance", 1.5f);
	}

	void Update(){
		staminaText.text = "Stamina: " + (maxTravelDistance * 10);
	}

	public IEnumerator WaitToKill()
	{
		yield return new WaitForSeconds (currentTravelDistance * 60);
		Destroy (battleContainer.gameObject);
		mapScene.SetActive (true);
	}
}
