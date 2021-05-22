using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMotor : MonoBehaviour
{
    
    Rigidbody2D rig;  

    Vector2 moviment;

    Animator anim;

    [SerializeField]
    float life = 100;


    void Start()
    {
   
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rig.velocity = moviment;

    }   

    public void Moviment(Vector2 moviment, float speed)
    {
        
        this.moviment = moviment.normalized * speed;       
        anim.SetFloat("XVelocity", moviment.x, 0.1f, Time.deltaTime);
    }   
     public void ApplyDamage(float damage)
    {
        life -= damage;
          if ( life < 0)
        {
            OnDeath();

        }
          else
        {
            anim.SetBool("TakeDamage", true);
        }
    }
    public void OnDeath()
    {
        anim.SetBool("IsDeath", true);
    }
}
