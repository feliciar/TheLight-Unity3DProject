using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public bool hasBathedInLight = false;

	public GameObject welcomePrefab;
	private int rescuedLights=0;
	public int numRescuedLightsForWin=1;

/*
	void Awake(){
		if(GameObject.FindGameObjectsWithTag("GameController").Length > 1){
			Destroy(this.gameObject);
			Debug.Log("Destroyed me");
		}
	}
*/
	void Start(){
		if(!Debug.isDebugBuild)
			Cursor.visible = false;
		StartNewGame();
		
	}

	// Update is called once per frame
	void Update () {
		if(rescuedLights>=numRescuedLightsForWin){
			SceneManager.LoadScene("Win");
			rescuedLights = 0;
		}
		if(Input.GetKeyDown(KeyCode.Escape)){
			//GoToScene("Menu");
			ExitApplication();
		}
	
	}

	public void SetHasBathedInLight(bool value){
		hasBathedInLight = value;
	}

	public void GoToScene(string sceneName){
		Debug.Log("Changing scenes to "+sceneName);
		
		

		SceneManager.LoadScene(sceneName);
	}

	public void AddRescuedLight(){
		rescuedLights++;
	}

	public void ExitApplication(){
		Application.Quit();
		Debug.Log("Exited");
	}

	public void StartNewGame(){
		Instantiate(welcomePrefab);
		SceneManager.LoadScene("Scene1");
	}

	
}
