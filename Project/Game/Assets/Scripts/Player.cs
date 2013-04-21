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
		
		if(mIsWorking && mProgress){
			Debug.Log("mProgress.sliderValue: "+mProgress.sliderValue+" "+Time.deltaTime);
			mProgress.sliderValue += workingSpeed*Time.deltaTime;
			if(mProgress.sliderValue == 1){
				mIsWorking = false;
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
		Vector3 newPos = new Vector3(pos.x, pos.y, pos.z);
		mTargetPos = newPos;
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
			transform.localScale = new Vector3(230, 260,0);
		}else{
			transform.position = transform.position - (delta * moveSpeed);
			transform.localScale = new Vector3(-230, 260,0);
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
			if(!mProgressBar){
				mProgressBar = (GameObject)Instantiate(mProgressBarGO);
			}
			mProgressBar.transform.parent = transform.parent;
			mProgressBar.transform.localScale = Vector3.one;
			Vector3 pos = new Vector3(transform.localPosition.x-80, transform.localPosition.y+140, -1);
			mProgressBar.transform.localPosition = pos;
			mProgress = mProgressBar.GetComponent<UISlider>();
			Debug.Log("mProgress: "+mProgress);
			mProgress.sliderValue = 0;
			mIsWorking = true;
		}
	}
}
