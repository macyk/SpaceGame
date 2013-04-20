using UnityEngine;
using System.Collections;

public class ClickAndGoTo : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnClick(){
		if(Controller.instance){
			Controller.instance.MovePlayer(gameObject.transform);
		}
	}
}
