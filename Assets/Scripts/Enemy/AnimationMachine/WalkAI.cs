using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkAI : StateMachineBehaviour {
    public float speed = 1;
    
    private EnemyAI enemyAI;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        enemyAI = animator.GetComponent<EnemyAI>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        enemyAI.transform.position = Vector2.MoveTowards(enemyAI.transform.position, enemyAI.player.position, speed * Time.fixedDeltaTime);

        var distance = Vector2.Distance(enemyAI.player.position, enemyAI.transform.position);
        if(distance <= enemyAI.attackRange * 2)
            enemyAI.AttackAnimation();

        enemyAI.LookAt();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
       
    }

    
}
