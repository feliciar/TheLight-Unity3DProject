using UnityEngine;
using System.Collections;

public class WalkAroundItem : MonoBehaviour {

	public GameObject itemToWalkAround;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//transform.RotateAround(itemToWalkAround.transform.position, Vector3.up, 1 * Time.deltaTime);

		//We want to make this object move forward a little bit, but 
		/*gameObject.transform
		*/
		Animator animator = GetComponent<Animator>();
		if(!animator.GetBool("HasSeenPlayer")){
			gameObject.transform.LookAt(itemToWalkAround.transform);
			gameObject.transform.Rotate(new Vector3(0,-89,0));
		}
	
	}
}
