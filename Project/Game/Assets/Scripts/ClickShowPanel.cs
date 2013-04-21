using UnityEngine;
using System.Collections;

public class ClickShowPanel : MonoBehaviour {
	public	Transform	tab;
	private	bool		mShow = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void Reset(){
		tab.gameObject.SetActive(false);
		mShow = false;
	}
	
	void OnClick(){
		if(Controller.instance){
			Controller.instance.RestSideList(this);
		}
		if(tab){
			if(!mShow){
				tab.gameObject.SetActive(true);
				mShow = true;
			}else{
				Reset();
			}
		}
	}
}
