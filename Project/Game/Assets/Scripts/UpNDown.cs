using UnityEngine;
using System.Collections;

public class UpNDown : MonoBehaviour {
	private float 	mStartHeight;
	public 	float	speed   = 50;        // up and down speed
 	public	float 	maxUpAndDown  = 50; 
	public 	float	angle   = -90;  
	public 	float 	toDegrees  = Mathf.PI/180;
	public	bool	isEnabled = true;
	
	void Start(){
	    mStartHeight = transform.localPosition.y;
	}
 
	void FixedUpdate(){
		if(isEnabled){
		    angle += speed * Time.deltaTime;
		    if (angle > 270) angle -= 360;
			Vector3 pos = new Vector3(transform.localPosition.x, mStartHeight + maxUpAndDown * (1 + Mathf.Sin(angle * toDegrees)) / 2 
				,transform.localPosition.z);
		    transform.localPosition = pos;
		}
	}
}
