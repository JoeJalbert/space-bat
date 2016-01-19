using UnityEngine;
using System.Collections;

public class BattleManage : MonoBehaviour {

	public MapStats mapStats;

	void Start()
	{
		mapStats = GameObject.FindObjectOfType<MapStats> ();
		mapStats.battleContainer = this.gameObject;
		StartCoroutine(mapStats.WaitToKill ());
	}
}
