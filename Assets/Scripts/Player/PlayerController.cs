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

    
    
    void Start()
    {
        motorsScript = GetComponent<PlayerMotor>();
        anim = GetComponent<Animator>();
        

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");


        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("AttackLeft");            
           
        }
        else if (Input.GetMouseButton(1))
        {
            anim.SetTrigger("AttackRight");
           
        }
    }

    public void FixedUpdate()
    {
        Vector2 motion = new Vector2(horizontal, vertical);
        motorsScript.Moviment(motion, speed);
    }

   

}
