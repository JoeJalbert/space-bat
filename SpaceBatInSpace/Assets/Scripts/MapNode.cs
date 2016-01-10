using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapNode : MonoBehaviour {

    public string id;
    //public List<GameObject> Connections = new List<GameObject>();

    private GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

	void OnMouseDown ()
    {
		/*
        if (player.GetComponent<MapControl>().Routes.Contains(this.gameObject))
        {
            player.GetComponent<MapControl>().SetNewLocation(this.gameObject);
        } 
        */

		if (player.GetComponent<MapStats> ().maxTravelDistance > Vector2.Distance (transform.position, player.transform.position)) 
		{
			player.GetComponent<MapStats>().maxTravelDistance -= Vector2.Distance(transform.position, player.transform.position);
			player.GetComponent<MapControl>().SetNewLocation(this.gameObject);
		}
	}

	void OnMouseOver()
	{
		GetComponent<LineRenderer> ().SetPosition (0, transform.position);
		GetComponent<LineRenderer> ().SetPosition (1, player.transform.position);

		if (player.GetComponent<MapStats> ().maxTravelDistance < Vector2.Distance (transform.position, player.transform.position)) {
			GetComponent<LineRenderer> ().SetColors (new Color (255, 0, 0), new Color (255, 0, 0));
		} else {
			GetComponent<LineRenderer>().SetColors(new Color(255, 255, 255), new Color(255, 255, 255));
		}

	}

	void OnMouseExit()
	{
		GetComponent<LineRenderer> ().SetPosition (0, transform.position);
		GetComponent<LineRenderer> ().SetPosition (1, transform.position);
	}
	
}
