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
    
    public float life = 100;


    SpriteRenderer spriteRenderer;

    public bool onDeath = false;


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
          if ( life <= 0)
        {
            OnDeath();
            anim.SetTrigger("IsDeath");           

        }
          else
        {
            StartCoroutine("TakeDamageColor");
            anim.SetTrigger("TakeDamage");
        }
       
    }

    public IEnumerator TakeDamageColor()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);

        spriteRenderer.color = Color.white;

    }
    public void OnDeath()
    {
        onDeath = true;
    }
  
}
