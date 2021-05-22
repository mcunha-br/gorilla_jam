using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkAI : StateMachineBehaviour {
    public float speed = 1;

    private EnemyAI enemyAI;
    private Rigidbody2D body;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        enemyAI = animator.GetComponent<EnemyAI>();
        body = animator.GetComponent<Rigidbody2D>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        var target = Vector2.MoveTowards(body.position, enemyAI.player.position, speed * Time.fixedDeltaTime);
        body.MovePosition(target);

        var distance = Vector2.Distance(enemyAI.player.position, body.position);
        if(distance <= enemyAI.attackRange * 2)
            enemyAI.AttackAnimation();

        enemyAI.LookAt();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
       
    }

    
}
