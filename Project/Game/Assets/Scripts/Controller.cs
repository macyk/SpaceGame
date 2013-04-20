using UnityEngine;
using System.Collections.Generic;

public class Controller : MonoBehaviour {
	public 	List<Player> 	playerList = new List<Player>();
	public 	float 			wlkingSpeed = 2.0f;
	public	float			distanceFromItem = 20f;
	private	Player			mPlayer;
	
	// Use this for initialization
	void Start () {
		
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
