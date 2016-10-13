using UnityEngine;
using System.Collections;

/*
 * Makes this gameobject go into the sky and activates the specified conversation. 
 */
public class LightEscape : MonoBehaviour {
	private float waitTime =1f;
	private float timer = 0f;
	private bool activatedConversation=false;
	public GameObject conversation;


	void FixedUpdate(){
		timer += Time.deltaTime;
		if(timer>=waitTime){
			this.gameObject.GetComponent<Rigidbody>().AddForce(0,2,0);
			if(!activatedConversation){
				conversation.SetActive(true);
				activatedConversation=true;
			}
		}
	}
}
