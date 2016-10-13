using UnityEngine;
using System.Collections;


public class MoveTowardPlayer : MonoBehaviour {

    private GameObject player;
    private GameObject weapon;
    public float forgetDistance = 18;
    public float waitDistance = 12; //Distance were the skeleton merely waits and sees

    private DecreasingPowerOfLight weaponScript;

    private AudioSource growling;

	
    void Start(){
        
        growling = gameObject.GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        weapon =  GameObject.FindGameObjectWithTag("PowerOfLight");
        if(weapon!=null)
            weaponScript = (DecreasingPowerOfLight)weapon.GetComponent("DecreasingPowerOfLight");
    }
	// Update is called once per frame
	void Update () {
        if(player == null){
            //Needed for some reason
            player = GameObject.FindGameObjectWithTag("Player");
        }
        if(weapon == null){
            weapon =  GameObject.FindGameObjectWithTag("PowerOfLight");
            if(weapon != null)
                weaponScript = (DecreasingPowerOfLight)weapon.GetComponent("DecreasingPowerOfLight");
        }
        SharpTurnAroundWithWaitAndForget();
	}

    void SharpTurnAroundWithWaitAndForget(){
        Animator animator = GetComponent<Animator>();
        float distance = Vector3.Distance(player.transform.position, transform.position);
        

        if(distance > forgetDistance){
            animator.SetBool("HasSeenPlayer", false);
            animator.SetBool("StandStill", false);
        }else {
             float realWaitDistance = waitDistance * weaponScript.weaponLeft;
             Debug.Log("Real wait distance: "+realWaitDistance);
             if(weapon !=null && weapon.activeSelf){
                realWaitDistance += 4; //So that the skeleton is more scared TODO fix this better
             }

            if(distance > realWaitDistance){
                //We wait
                animator.SetBool("HasSeenPlayer", false);
                animator.SetBool("StandStill", true);

                transform.LookAt(player.transform.position);
                Debug.Log("Should stand still");

                if(growling.isPlaying == false)
                    growling.Play();
            }else{
                //We run towards or against the player
                animator.SetBool("HasSeenPlayer", true);
                animator.SetBool("StandStill", false);

                if (weapon!=null && !weapon.activeSelf) {
                
                    //Rotate towards the player
                    transform.LookAt(player.transform.position);
                } else {
                    transform.LookAt(player.transform.position);
                    transform.Rotate(0, 180, 0);
                }
                Debug.Log("Should run");
                

            }

         
        }
        /*animator.SetBool("StandStill", true);
        Debug.Log("Standstill is set to true");
        Debug.Log(animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Walk"));
        Debug.Log(animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Run"));
        Debug.Log(animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Stand Still"));
*/
    }

    void SharpTurnAround() {
        Animator animator = GetComponent<Animator>();
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance > forgetDistance) {
            animator.SetBool("HasSeenPlayer", false);
            return;
        } 
            

        animator.SetBool("HasSeenPlayer", true);
        if (!weapon.activeSelf) {
            
            //Rotate towards the player
            transform.LookAt(player.transform.position);
        } else {
            transform.LookAt(player.transform.position);
            transform.Rotate(0, 180, 0);
        }

    }
}
