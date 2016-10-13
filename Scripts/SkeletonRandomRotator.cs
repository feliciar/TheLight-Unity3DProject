using UnityEngine;
using System.Collections;

public class SkeletonRandomRotator : MonoBehaviour {

    public float rotationRate = 20;
    public float timeBetweenUpdates = 2f;
    float timeLeft;

    void Start () {
        timeLeft = timeBetweenUpdates;
    }
	
	void Update () {

        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0) {
            float y = (Random.value - 0.5f) * rotationRate;
            transform.Rotate(new Vector3(0, y, 0));
            timeLeft = timeBetweenUpdates;
        }

    }
}
