using UnityEngine;
using System.Collections;


/*
 * This class performs the action when the player hits the right button
 * It is dependent on that this script is attached to a chest that has an animator,
 * that has a bool called CanOpen. 
 * It is also dependent on that the light has a script called LightEscape. 
 * 
 */
public class ChestController : MonoBehaviour {
	private Animator chestControl;
	public GameObject theLight;
	private GameObject player;

	void Start(){
		player = GameObject.FindGameObjectWithTag("Player");
	}


	public void SecondAction(bool isDown){
		Debug.Log("Got a message for second action");

		Camera cam = Camera.main;
		Vector3 viewportPoint = cam.WorldToViewportPoint(gameObject.transform.position);
		if(viewportPoint.x>=0 && viewportPoint.x<=1 && 
			viewportPoint.y>=0 && viewportPoint.y<=1 && 
			viewportPoint.z>=0){


			//bool skeletonCloseBy = false;
			GameObject[] skeletons = GameObject.FindGameObjectsWithTag("Skeleton");
			foreach(GameObject s  in skeletons){
				if(10 > Vector3.Distance(s.transform.position,this.gameObject.transform.position)){
					//skeletonCloseBy = true;
					return;
				}
			}

			if(10 < Vector3.Distance(player.transform.position, gameObject.transform.position)){
				return;
			}

			//Open chest
			chestControl = this.gameObject.GetComponentInChildren<Animator>();
			chestControl.SetBool("CanOpen",true);
			
			LightEscape l = (LightEscape)theLight.GetComponent("LightEscape");
			l.enabled = true;

			
		}

	}
}
