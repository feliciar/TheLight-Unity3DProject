using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/*
 * This class makes the camera bathe in light. 
 * It does this by making the light go closer and closer the player, 
 * and when it's really close the light increases in scale to animate
 * that it is even closer.  
 * It then changes scenes to BathingInLight. 
 */
public class BathingInLight : MonoBehaviour {

	public GameObject theLight;
	private GameObject player;

	void Start () {
		player = GameObject.FindGameObjectWithTag("MainCamera");
		
	}


	void FixedUpdate(){

		Vector3 directionOfForce = player.transform.position - theLight.transform.position;
		if(directionOfForce.magnitude<1.5){
			theLight.transform.localScale += new Vector3(5,5,5);
			this.enabled = false;

			//Change is equipable of object
			GameController script = (GameController)GameObject.FindGameObjectWithTag("GameController").GetComponent("GameController");
			script.SetHasBathedInLight(true);

			Destroy(this.gameObject);
			SceneManager.LoadScene("BathingInLight");
		}else{
			theLight.GetComponent<Rigidbody>().AddForce(directionOfForce*10);

		}
	}
}
