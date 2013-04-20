using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public 	int 			playerID;
	public	Controller		controller;
	private	int 			mPlayerID;
	private	UISlicedSprite	mUIButton;
	private	float			mSpeed;
	private	Vector3			mTargetPos;
	private	bool			mMove = false;
	private	bool			mMoveLeft = false;
	private	float			mDistance = 20f;
		
	// Use this for initialization
	void Start () {
		mPlayerID = playerID;
		mUIButton = gameObject.GetComponent<UISlicedSprite>();
		if(controller){
			mSpeed = controller.wlkingSpeed;
			mDistance = controller.distanceFromItem;
		}else{
			Debug.LogWarning("Controller is missing");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(mMove){
			if(mMoveLeft)
			{
				if(transform.position.x < (mTargetPos.x + 0.1f)){
					mMove = false;
				}
			}else{
				if(transform.position.x > (mTargetPos.x - 0.1f)){
					mMove = false;
				}
			}
			Move();
		}
	}
	
	public int GetID() {
		return mPlayerID;
	}
	
	void OnClick(){
		if(controller){
			controller.SetPlayer(this);
		}
	}
	
	public void MoveTo(Vector3 pos){
		Vector3 newPos = new Vector3(pos.x, pos.y, 0);
		mTargetPos = newPos;
		mMove = true;
		Debug.Log("MoveTo: " + mTargetPos);
	}
	
	void Move()
	{
		Vector3 delta = GetTargetPos();
        delta.Normalize();
        float moveSpeed = mSpeed * Time.deltaTime/10;
		if(mMoveLeft){
        	transform.position = transform.position + (delta * moveSpeed);
		}else{
			transform.position = transform.position - (delta * moveSpeed);
		}
	}
	
	Vector3 GetTargetPos(){
		if(transform.position.x > mTargetPos.x)
		{
			mMoveLeft = true;
			return transform.position + mTargetPos;
		}else{
			mMoveLeft = false;
			return transform.position - mTargetPos;
		}
	}
}
