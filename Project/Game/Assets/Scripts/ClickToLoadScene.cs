using UnityEngine;
using System.Collections;

public class ClickToLoadScene : MonoBehaviour {
	public string	sceneName;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnClick(){
		if(sceneName.Length>0){
			Application.LoadLevel(sceneName);
		}
	}
}
