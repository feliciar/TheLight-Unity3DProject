using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/*
 * This class handles player collision checks. If the player collides with a skeleton
 * she should die. 
 * It then loads the "Dead"-scene
 */
public class CollisionCheck : MonoBehaviour {

	
    void OnCollisionEnter(Collision collision) {
        if(collision.collider.tag == "Skeleton") {
            Debug.Log("Lost game");
            SceneManager.LoadScene("Dead");
        }
    }
}
