using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MapControl : MonoBehaviour {

    public GameObject mapGen;
    public GameObject currentPosition;

	public Text planetText;

    //public List<GameObject> Routes = new List<GameObject>();

    void Start () {
        StartCoroutine(DelayStart());
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Return)) {
			Application.LoadLevel(4);
		}

		planetText.text = "Planet " + currentPosition.GetComponent<MapNode>().id;
	}

    public void SetNewLocation(GameObject newLocation)
    {
        currentPosition = newLocation;
        Vector3 tempo = currentPosition.transform.position;
        tempo.z = -1;
        transform.position = tempo;

        //Routes = currentPosition.GetComponent<MapNode>().Connections;

    }
	
    IEnumerator DelayStart()
    {
        yield return new WaitForSeconds(.1f);
        SetNewLocation(mapGen.GetComponent<MapGen>().tempNodes[0]);
    }
}
