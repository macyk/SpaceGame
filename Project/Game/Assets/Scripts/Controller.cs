using UnityEngine;
using System.Collections.Generic;

public class Controller : MonoBehaviour {
	public 	List<Player> 	playerList = new List<Player>();
	public 	float 			wlkingSpeed = 2.0f;
	public	float			distanceFromItem = 20f;
	public	GameObject		progressBar;
	
	private	Player			mPlayer;
	public	Controller		controller;
	static 	Controller 		mInstance;
	public 	static Controller instance { get {return mInstance;}}
	
	// Use this for initialization
	void Start () {
		if(mInstance == null)
		{
			mInstance = this;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public Player GetPlayer(){
		return mPlayer;
	}
	
	public void SetPlayer(Player player){
		mPlayer = player;
	}
	
	public void MovePlayer(Transform trans){
		if(mPlayer){
			mPlayer.MoveTo(trans.position);
		}else{
			Debug.Log("No Player Selected");
		}
	}
}
