using UnityEngine;
using System.Collections;

public class PersistThisObject : MonoBehaviour {

	public GameObject objectToPersist;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(objectToPersist);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
