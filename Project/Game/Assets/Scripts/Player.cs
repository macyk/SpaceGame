using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public 	int 			playerID;
	private	int 			mPlayerID;
	private	UISlicedSprite	mUIButton;
	private	float			mSpeed;
	private	Vector3			mTargetPos;
	private	bool			mMove = false;
	private	bool			mMoveLeft = false;
	private	float			mDistance = 20f;
	private	bool			mSetup = false;
	private	GameObject		mProgressBarGO;
	private	GameObject		mProgressBar;
		
	// Use this for initialization
	void Start () {
		mPlayerID = playerID;
		mUIButton = gameObject.GetComponent<UISlicedSprite>();
	}
	void Init(){
		if(Controller.instance){
			mSpeed = Controller.instance.wlkingSpeed;
			mDistance = Controller.instance.distanceFromItem;
			if(Controller.instance.progressBar!=null){
				mProgressBarGO = Controller.instance.progressBar;
			}
			mSetup = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		if(mMove){
			if(mMoveLeft){
				if(transform.position.x < (mTargetPos.x + 0.1f)){
					mMove = false;
					ShowProgressBar();
				}
			}else{
				if(transform.position.x > (mTargetPos.x - 0.1f)){
					mMove = false;
					ShowProgressBar();
				}
			}
			Move();
		}
		
		if(!mSetup){
			Init();
		}
	}
	
	public int GetID() {
		return mPlayerID;
	}
	
	void OnClick(){
		if(Controller.instance){
			Controller.instance.SetPlayer(this);
		}
	}
	
	public void MoveTo(Vector3 pos){
		Vector3 newPos = new Vector3(pos.x, pos.y, pos.z);
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
	
	void ShowProgressBar(){
		if(mProgressBarGO!=null){
			mProgressBar = (GameObject)Instantiate(mProgressBarGO);
			mProgressBar.transform.parent = transform.parent;
			mProgressBar.transform.localScale = Vector3.one;
			Vector3 pos = new Vector3(transform.localPosition.x-80, transform.localPosition.y+140, 0);
			mProgressBar.transform.localPosition = pos;
		}
	}
}
