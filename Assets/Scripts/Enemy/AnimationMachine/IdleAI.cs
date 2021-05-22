using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAI : StateMachineBehaviour {

    private float randomize;
    private EnemyAI enemyAI;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        enemyAI = animator.GetComponent<EnemyAI>();
        randomize = Random.Range(2, 5);        
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        randomize -= Time.fixedDeltaTime;
        if(randomize <= 0) 
            animator.Play("Walk");           
        
        var distance = Vector2.Distance(enemyAI.player.position, enemyAI.transform.position);
        if(distance <= enemyAI.attackRange * 2)
            enemyAI.AttackAnimation();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
       
    }

    
}
