using UnityEngine;
using System.Collections.Generic;

public class Controller : MonoBehaviour {
	public 	List<Player> 		playerList = new List<Player>();
	public 	float 				wlkingSpeed = 2.0f;
	public	float				distanceFromItem = 20f;
	public	UILabel				score;
	public	GameObject			progressBar;
	public	GameObject			menu;
	public	Transform			UIPanel;
	public	MenuMission			sharedMenu;
	public	List<ClickShowPanel>sidePanels;
	public	GameObject			missionMenu;
	public	GameObject			secondMission;
	public	Transform			missionTran;
	
	private	Player			mPlayer;
	public	Controller		controller;
	static 	Controller 		mInstance;
	public 	static Controller instance { get {return mInstance;}}
	private	ClickAndGoTo	mClickAGoTo;
	private	GameObject		mMenu;
	private	int				mScore = 100;
	
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
	
	public void MovePlayer(Transform trans, ClickAndGoTo click){
		if(mPlayer){
			mClickAGoTo = click;
			mPlayer.MoveTo(trans.localPosition);
		}else{
			Debug.Log("No Player Selected");
		}
	}
	
	public void ResetClick(){
		if(mClickAGoTo){
			mClickAGoTo.Reset();
		}
	}
	
	public void TaskComplete(){
		if(menu&&UIPanel){
			mMenu = (GameObject)Instantiate(menu);
			mMenu.transform.parent = UIPanel.gameObject.transform;
			mMenu.transform.localScale = Vector3.one;
			mMenu.transform.localPosition = new Vector3(0,0,-2);
			mScore += 100;
			UpdateScore();
			AddNextTask();
		}
	}
	
	void UpdateScore(){
		if(score){
			score.text = mScore.ToString();
		}
	}
	
	public void RestSideList(ClickShowPanel obj){
		if(sidePanels.Count>0){
			for(int i = 0; i<sidePanels.Count; i++)
			{
				if(obj!= sidePanels[i]){
					sidePanels[i].Reset();
				}
			}
		}
	}
	
	public void RestAllSideList(){
		if(sidePanels.Count>0){
			for(int i = 0; i<sidePanels.Count; i++)
			{
				sidePanels[i].Reset();
			}
		}
	}
	
	public void ShowMission(string txt, string btnTxt){
		if(sharedMenu){
			sharedMenu.gameObject.SetActive(true);
			sharedMenu.des.text = txt;
			sharedMenu.btnTxt.text = btnTxt;
		}
	}
	
	void AddNextTask(){
		if(missionTran && secondMission){
			GameObject obj = (GameObject)Instantiate(secondMission);
			obj.transform.parent = missionTran.transform;
			obj.transform.localScale = Vector3.one;
			obj.transform.localPosition = new Vector3(-32, 218, -9);
		}
	}
}
