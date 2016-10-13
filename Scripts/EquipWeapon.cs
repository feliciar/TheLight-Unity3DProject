using UnityEngine;
using System.Collections;

/*
 * This class is dependent on the gamecontroller script having a bool called
 * hasBathedInLight
 */
public class EquipWeapon : MonoBehaviour {

    public GameObject weapon; 
    GameController gc;
    

	// Use this for initialization
	void Start () {
        gc = (GameController)GameObject.FindGameObjectWithTag("GameController").GetComponent("GameController");
	
	}
	
	// Update is called once per frame
	void Update () {
        /*
      if (Input.GetMouseButtonDown(0) && gc.hasBathedInLight) { //Left button
                Debug.Log("Setting weapon to active");
                weapon.SetActive(true);
            }
            if(Input.GetMouseButtonUp(0)) {
                weapon.SetActive(false);
            }
            */
    }

    public void FirstAction(bool isTrue){
        Debug.Log("Got a message for first action");
         if (isTrue && gc.hasBathedInLight) { //Left button
                Debug.Log("Setting weapon to active");
                weapon.SetActive(true);
        }
        if(!isTrue) {
            weapon.SetActive(false);
        }
    }
}
