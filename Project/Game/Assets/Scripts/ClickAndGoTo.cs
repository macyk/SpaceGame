using UnityEngine;
using System.Collections;

public class ClickAndGoTo : MonoBehaviour {
	private	bool mClicked = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnClick(){
		if(Controller.instance && !mClicked){
			Controller.instance.MovePlayer(gameObject.transform, this);
			mClicked = true;
		}
	}
	
	public void Reset(){
		mClicked = false;
	}
}
