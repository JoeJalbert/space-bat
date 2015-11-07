using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapNode : MonoBehaviour {

    public int id;
    public List<GameObject> Connections = new List<GameObject>();

    private GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

	void OnMouseDown ()
    {
        if (player.GetComponent<MapControl>().Routes.Contains(this.gameObject))
        {
            player.GetComponent<MapControl>().SetNewLocation(this.gameObject);
        }    
	}
	
}
