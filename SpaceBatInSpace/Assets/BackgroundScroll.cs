using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BackgroundScroll : MonoBehaviour {

	void Update () 
	{
		MeshRenderer mr = GetComponent<MeshRenderer> ();

		Material mat = mr.material;

		Vector2 offset = mat.mainTextureOffset;

		offset.y += Time.deltaTime / 15;

		mat.mainTextureOffset = offset;
	}

}
