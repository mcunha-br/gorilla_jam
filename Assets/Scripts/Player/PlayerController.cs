using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{

    PlayerMotor motorsScript;
    Animator anim;

   

    [SerializeField]
     float speed;

    float horizontal;
    float vertical;
    
    [SerializeField]
    public float AttackTime;
    float CanAttack = 1f;

    

    
    
    void Start()
    {
        motorsScript = GetComponent<PlayerMotor>();
        anim = GetComponent<Animator>();
        

    }

    // Update is called once per frame
    public void Update()
    {
        AttackTime += Time.deltaTime;       



            if (motorsScript.onDeath == true)
            {
                
                return;
            }

            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");



            if (AttackTime >= CanAttack)
            {

                if (Input.GetMouseButtonDown(0))
                {

                    anim.SetTrigger("AttackLeft");
                    AttackTime = 0;

                }
                else if (Input.GetMouseButton(1))
                {

                    anim.SetTrigger("AttackRight");
                    AttackTime = 0;

                }
            }
        
    }
    public void FixedUpdate()
    {
        Vector2 motion = new Vector2(horizontal, vertical);
        motorsScript.Moviment(motion, speed);
    }

   

}
