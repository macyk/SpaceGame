using UnityEngine;
using System.Collections;

public class MenuConfirmBtn : MonoBehaviour {
	public Transform	menu;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnClick(){
		if(menu)menu.gameObject.SetActive(false);
	}
}
