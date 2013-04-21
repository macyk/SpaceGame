using UnityEngine;
using System.Collections;

public class ClickToLoadMission : MonoBehaviour {
	public 	string 		missionDes;
	public 	string 		btnDes;
	private	GameObject	mMenu;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnClick(){
		if(Controller.instance){
			Controller.instance.RestAllSideList();
			if(Controller.instance.sharedMenu){
				Controller.instance.ShowMission(missionDes, btnDes);
			}else{
				
				Debug.LogWarning("the mission menu prefab is missing");
			}
		}
	}
}
