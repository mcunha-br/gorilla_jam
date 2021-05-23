using UnityEngine;

public class EntryAI : StateMachineBehaviour {

    private EnemyAI enemyAI;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        enemyAI = animator.GetComponent<EnemyAI>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        enemyAI.LookAt();
        if(GameManager.state == GameState.INGAME)
            animator.Play("Idle");
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
       
    }    
}