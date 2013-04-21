using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public 	int 				playerID;
	public	float				workingSpeed = 0.1f;
	private	int 				mPlayerID;
	private	UISlicedSprite		mUIButton;
	private	float				mSpeed;
	private	Vector3				mTargetPos;
	private	bool				mMove = false;
	private	bool				mMoveLeft = false;
	private	float				mDistance = 20f;
	private	bool				mSetup = false;
	private	GameObject			mProgressBarGO;
	private	GameObject			mProgressBar;
	private	UISpriteAnimation	mAni;
	private	UpNDown				mUpNDown;
	private	bool				mIsWorking = false;
	private	UISlider			mProgress;
		
	// Use this for initialization
	void Start () {
		mPlayerID = playerID;
		mUIButton = gameObject.GetComponent<UISlicedSprite>();
		mAni = gameObject.GetComponent<UISpriteAnimation>();
		if(mAni)mAni.enabled = false;
		mUpNDown = gameObject.GetComponent<UpNDown>();
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
				if(transform.localPosition.x < (mTargetPos.x + 100f)){
					//Debug.Log("transform.position.x: "+transform.localPosition.x + "  "+(mTargetPos.x + 0.1f));
					mMove = false;
					ShowProgressBar();
				}
			}else{
				if(transform.localPosition.x > (mTargetPos.x - 100f)){
					//Debug.Log("transform.position.x: "+transform.localPosition.x + "  "+(mTargetPos.x + 0.1f));
					mMove = false;
					ShowProgressBar();
				}
			}
			Move();
		}
		
		if(!mSetup){
			Init();
		}
		
		if(mIsWorking && mProgress){
			mProgress.sliderValue += workingSpeed*Time.deltaTime;
			if(mProgress.sliderValue == 1){
				mIsWorking = false;
				Controller.instance.ResetClick();
				Controller.instance.TaskComplete();
				Destroy(mProgress.gameObject);
			}
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
		Vector3 newPos = new Vector3(pos.x, transform.localPosition.y, -2);
		Debug.Log("newPos "+ newPos);
		mTargetPos = newPos;
		if(transform.localPosition.x > mTargetPos.x)
		{
			Debug.Log("Left: " +transform.localPosition + " "+ mTargetPos);
			mMoveLeft = true;
		}else{
			mMoveLeft = false;
			Debug.Log("Right: " +transform.localPosition + " "+ mTargetPos);
		}
		mMove = true;
	}
	
	void Move()
	{
		Vector3 delta = GetTargetPos();
        delta.Normalize();
        float moveSpeed = mSpeed * Time.deltaTime/10;
		if(mAni)mAni.enabled = true;
		if(mUpNDown) mUpNDown.isEnabled = false;
		if(mMoveLeft){
        	transform.position = transform.position + (delta * moveSpeed);
			transform.localScale = new Vector3(230, 260,1);
		}else{
			transform.position = transform.position - (delta * moveSpeed);
			transform.localScale = new Vector3(-230, 260,1);
		}
	}
	
	Vector3 GetTargetPos(){
		if(mMoveLeft)
		{
			Debug.Log("Left: " +transform.localPosition + " "+ mTargetPos);
			return transform.localPosition + mTargetPos;
		}else{
			Debug.Log("Right: " +transform.localPosition + " "+ mTargetPos);
			return transform.localPosition - mTargetPos;
		}
	}
	
	void ShowProgressBar(){
		if(mProgressBarGO!=null){
			if(!mProgressBar){
				mProgressBar = (GameObject)Instantiate(mProgressBarGO);
			}
			mProgressBar.transform.parent = transform.parent;
			mProgressBar.transform.localScale = Vector3.one;
			Vector3 pos = new Vector3(transform.localPosition.x-80, transform.localPosition.y+140, -1);
			mProgressBar.transform.localPosition = pos;
			mProgress = mProgressBar.GetComponent<UISlider>();
			mProgress.sliderValue = 0;
			mIsWorking = true;
		}
	}
}
