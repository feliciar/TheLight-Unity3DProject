using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class WaitAndReturnToMainScene : MonoBehaviour {

	public float timer = 5f;
	private float time = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		time+=Time.deltaTime;
		if(time>=timer){
			SceneManager.LoadScene("Scene1");
			//GameObject.FindGameObjectWithTag("Player").GetComponents<Script>();
		}
	}
}
