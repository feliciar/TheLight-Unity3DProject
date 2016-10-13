using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]

public class SkeletonRootMotionControl : MonoBehaviour {

    public float walkSpeed = 16f;
    public float runSpeed = 22f;
    void OnAnimatorMove() {
        Animator animator = GetComponent<Animator>();
        
      
    
        if (animator) {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Walk")) {
                //animator.SetBool("HasSeenPlayer", true);
                //The skeleton should walk at a constant speed, dependent on the direction it's facing

                float distance = animator.GetFloat("WalkSpeed") * Time.deltaTime * walkSpeed;
                transform.position += transform.forward * distance;
                /*
                //The skeleton should not be inhibited by slopes. 
                Ray myRay = new Ray(gameObject.transform.position, transform.forward);
                 RaycastHit hit;
     
                if (Physics.Raycast(myRay, out hit, distance)){
                     if (hit.collider.gameObject.tag == "Ground"){ // Our Ray has hit the ground
                        //TODO change this
                        //Ugly solution that only works in small slopes
                        //transform.position += new Vector3(0,0.1f,0);
                    }
                }
                */

                //Rigidbody rigidBody = gameObject.GetComponent<Rigidbody>();
                //rigidBody.velocity = new Vector3(1, rigidBody.velocity.y, 1);

            }else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Run")){
                transform.position += transform.forward * Time.deltaTime * runSpeed;

            }
            //The skeleton should only rotate around the y-axis, not the x nor z

            //transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);



        }


        

    }

 
}


