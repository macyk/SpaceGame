using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public 	int 		playerID;
	public	Controller	controller;
	private	int 		mPlayerID;
	private	UIButton	mUIButton;
	
	// Use this for initialization
	void Start () {
		mPlayerID = playerID;
		mUIButton = gameObject.GetComponent<UIButton>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public int GetID() {
		return mPlayerID;
	}
	
	void OnClick(){
		if(controller){
			controller.SetPlayer(this);
			mUIButton.isEnabled = false;
		}
	}
	
	public void MoveTo(Transform trans){
		Debug.Log(trans);
	}
}
