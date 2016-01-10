using UnityEngine;
using System.Collections;

public class ButtonScripts : MonoBehaviour {

	public void LoadScene(int i){
		Application.LoadLevel (i);
	}

	public void QuitGame(){
		Application.Quit ();
	}
}
