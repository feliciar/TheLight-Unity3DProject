using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;


/*
 * This class is responsible for playing a conversation for the player. 
 * It reads a file for the manuscript.
 */
public class Conversation : MonoBehaviour {
    public GameObject gameObjectToTriggerWhenFinished;
    public float timeBetweenMessages = 4f;
	public KeyCode[] keysForNextMessage = {KeyCode.Return}; 

    public TextAsset textFile;
	
	private float messageTimer = 0f;
	
	private ArrayList lines;
    private IEnumerator enumLines;
    

	// Use this for initialization
	void Start () {

        gameObject.GetComponent<Canvas> ().worldCamera = Camera.main;
         gameObject.GetComponent<Canvas> ().planeDistance = 1;

		
        lines = new ArrayList();

        LoadTextAsset();
        enumLines = lines.GetEnumerator();

        UpdateText();
	}
	
	/*
	 * This update method updates the text shown, if 
	 * the player has pressed return, or if the timer has run out
	 */
	void Update () {
        messageTimer+=Time.deltaTime;
        if(messageTimer>=timeBetweenMessages){
             UpdateText();
             messageTimer = 0f;
        }
		foreach(KeyCode key in keysForNextMessage){
			if(Input.GetKeyDown(key)){
				UpdateText();
				messageTimer = 0f;
			}
		}
		
	}

    private void UpdateText() {
        UnityEngine.UI.Text text = GetComponentInChildren<UnityEngine.UI.Text>();
        if(enumLines.MoveNext())
            text.text = (string)enumLines.Current;
        else {
            if(gameObjectToTriggerWhenFinished!=null){
        	   gameObjectToTriggerWhenFinished.SetActive(true);
            }
            gameObject.SetActive(false);
        }
    }

    /*
     * Loads the contents of a specified into the array lines
     */
     /*
    private bool Load() {
        try {
            string line;
            StreamReader theReader = new StreamReader(fileName, Encoding.Default);
            
            using (theReader) {
                do {
                    line = theReader.ReadLine();

                    if (line != null) {
                        lines.Add(line);
                    }
                }
                while (line != null);
                theReader.Close();
                return true;
            }
        }
            catch (System.Exception e) {
            Debug.Log("Could not find the correct file for the light. \n"+ e.Message);
            return false;
        }
    }
    */

    private bool LoadTextAsset(){
        try{
            string allText = textFile.text;
            string[] split = allText.Split('\n');
            lines = new ArrayList(split);
            return true;
        }catch(System.Exception e){
            Debug.Log("No file specified for conversation. \n" + e.Message);
            return false;
        }
    }
}
