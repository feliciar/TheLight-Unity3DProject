using UnityEngine;
using System.Collections;

/*
 * Hovers this object
 */
public class Hovering : MonoBehaviour {

    public float timeBetweenUpdates = 0.5f;
    public float speed = 0.8f;
    private float timeLeft;
    Vector3 hoveringCenterPosition;

    // Use this for initialization
    void Start() {
        timeLeft = timeBetweenUpdates;
        hoveringCenterPosition = gameObject.transform.position;

    }

  

    void FixedUpdate() {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0) {

            Vector3 newPosition = Random.insideUnitSphere + hoveringCenterPosition;
            Vector3 direction = newPosition - transform.position;

            GetComponent<Rigidbody>().velocity = direction*speed;
            timeLeft = timeBetweenUpdates;
        }

   
    }
}
