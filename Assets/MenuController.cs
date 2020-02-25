using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {
	bool menu = false;

	public void Exit(){
		Application.Quit();
	}

	public void Les(){
		Application.LoadLevel ("garden");
	}

	public void Gora(){
		Application.LoadLevel("mountain");
	}

	public void MenuButton(){

		if (!menu){
			menu = true;
			GameObject.Find ("CanvasMenu").GetComponent<Canvas>().enabled = true;
		}

		else {
						menu = false;
						GameObject.Find ("CanvasMenu").GetComponent<Canvas> ().enabled = false;
				}

	}
}
