using UnityEngine;
using System.Collections;

public class ClickAndGoTo : MonoBehaviour {
	public Controller controller;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnClick(){
		if(controller){
			controller.MovePlayer(gameObject.transform);
		}
	}
}
