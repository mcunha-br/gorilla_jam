using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchAI : StateMachineBehaviour {

    private float cooldown;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        cooldown = 10;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        cooldown -= Time.fixedDeltaTime;
        if(cooldown <= 0)
            animator.Play("Idle");
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
       
    }

    
}
