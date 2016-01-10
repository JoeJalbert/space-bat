using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MapStats : MonoBehaviour {

	public float maxTravelDistance;

	public Text staminaText;

	void Start () {
		maxTravelDistance = PlayerPrefs.GetFloat ("maxTravelDistance", 1.5f);
	}

	void Update(){
		staminaText.text = "Stamina: " + (maxTravelDistance * 10);
	}
}
