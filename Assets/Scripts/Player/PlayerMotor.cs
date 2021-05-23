using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMotor : MonoBehaviour
{
    

    Transform target;

    Rigidbody2D rig;  

    Vector2 moviment;

    Animator anim;

    [SerializeField]
    
    public float life = 100;

    PlayerController playerController;

    SpriteRenderer spriteRenderer;

    public bool onDeath = false;





    void Start()
    {
        
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerController = GetComponent<PlayerController>();
        target = FindObjectOfType<EnemyAI>().transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.x > target.position.x)
        {
            transform.rotation = Quaternion.Euler(0, -180, 0);
        }
        else
        {
            transform.rotation = Quaternion.identity;
        }

        rig.velocity = moviment;

    }   

    public void Moviment(Vector2 moviment, float speed)
    {
        if(GameManager.state == GameState.INGAME)
        {
            this.moviment = moviment.normalized * speed;       
            anim.SetFloat("XVelocity", moviment.x, 0.1f, Time.deltaTime);
        }
    }   
     public void ApplyDamage(float damage)
    {      

        life -= damage;
          if ( life <= 0)
        {
            OnDeath();
            GameManager.Instance.WinAndLoseGame("You Lose!!");
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
        playerController.AttackTime = 0;
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);

        spriteRenderer.color = Color.white;

    }
    public void OnDeath()
    {
        onDeath = true;
    }
    
  
}
