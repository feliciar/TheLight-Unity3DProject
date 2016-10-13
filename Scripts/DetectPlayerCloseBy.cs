using UnityEngine;
using System.Collections;

public class DetectPlayerCloseBy : MonoBehaviour {
    public float distance = 3;
    public GameObject gameObjectToTrigger;
	
	
	void Update () {
        if(this==null)
            return;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player == null){
            return;
        }
        if (Vector3.Distance(transform.position, player.transform.position) < distance) {
            gameObjectToTrigger.SetActive(true);
            this.enabled = false;
        }
       
	}
}
