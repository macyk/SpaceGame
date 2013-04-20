using UnityEngine;
using System.Collections;

public class Shadow : MonoBehaviour {
	public Transform	player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(player){
			Vector3 pos = new Vector3(player.position.x, transform.position.y, transform.position.z);
			transform.position = pos;
		}
	}
}
