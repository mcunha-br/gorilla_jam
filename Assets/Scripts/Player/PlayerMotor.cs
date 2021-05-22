using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    Rigidbody2D rig;    
    

    Vector2 moviment;

    Animator anim;    

    float valueClampX = 3.8f;
    float valueClampY = 3.3f;


    [SerializeField]
    float life = 100;


    bool isDeath;
    bool takeDamage;


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
    private void Update()
    {
        Clamp();
    }

    public void Moviment(Vector2 moviment, float speed)
    {
        this.moviment = moviment.normalized * speed;
        anim.SetFloat("XVelocity", moviment.x, 0.1f, Time.deltaTime);
    }    
    private void Clamp()
    {
        Vector2 newPosition = transform.localPosition;
        newPosition.x = Mathf.Clamp(newPosition.x, -valueClampX, valueClampX);
        newPosition.y = Mathf.Clamp(newPosition.y, -valueClampY, valueClampY);
        transform.localPosition = newPosition;
    }

    public void AplyDamage(int damage)
    {

        life -= damage;
        if (life <= 0)
        {
            isDeath = true;
            OnDeath();

        }
        else
        {
            StartCoroutine("TakeDamage");
            anim.SetBool("takeDamage", takeDamage);
        }

    }
    public void OnDeath()
    {

        anim.SetBool("IsDeath", isDeath);
        Destroy(gameObject.GetComponent<CapsuleCollider2D>());
        Destroy(gameObject, 0.5f);
    }

    IEnumerator TakeDamage()
    {
        takeDamage = true;
        yield return new WaitForSeconds(0.3f);
        takeDamage = false;
    }
}
