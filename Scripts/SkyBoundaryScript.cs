using UnityEngine;
using System.Collections;

public class SkyBoundaryScript : MonoBehaviour {

	public int rescuedLights=0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerExit(Collider c) {
		if(c.gameObject.tag=="Light"){
			LightEscape l = (LightEscape)c.gameObject.GetComponent("LightEscape");
			l.enabled = false;
			GameController gc = GameObject.FindGameObjectWithTag("GameController").GetComponent("GameController") as GameController;
			gc.AddRescuedLight();
		}
    }
}
