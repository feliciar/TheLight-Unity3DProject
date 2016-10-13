using UnityEngine;
using System.Collections;

public class PlayerInputHandler : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {

		if(Input.GetMouseButtonDown(0)){
			Debug.Log("FirstAction click!");
			gameObject.SendMessage("FirstAction",true);
		}
		else if(Input.GetMouseButtonUp(0))
			gameObject.SendMessage("FirstAction",false);
		


		gameObject.SendMessage("MovementInput",GetInput());
		if(Input.GetMouseButtonDown(1)){
			GameObject[] chests = GameObject.FindGameObjectsWithTag("ChestWithTrappedLight");
			foreach(GameObject chest in chests){
				chest.SendMessage("SecondAction",true);
			}
			
		}
		
		if(UnityStandardAssets.CrossPlatformInput.CrossPlatformInputManager.GetButtonDown("Jump")){
			gameObject.SendMessage("JumpAction");
		}

		

	
	}

	void FixedUpdate(){

	}

	private Vector2 GetInput(){
            
        Vector2 input = new Vector2
            {
            	x = Input.GetAxis("Horizontal"),
            	y = Input.GetAxis("Vertical")
             //   x = UnityStandardAssets.CrossPlatformInput.CrossPlatformInputManager.GetAxis("Horizontal"),
               // y = UnityStandardAssets.CrossPlatformInput.CrossPlatformInputManager.GetAxis("Vertical")
            };
        return input;
    }


}
