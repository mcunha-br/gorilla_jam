using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    PlayerMotor motorsScript;
   

    [SerializeField]
    float speed;




    float horizontal;
    float vertical;
    
    void Start()
    {
        motorsScript = GetComponent<PlayerMotor>();

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

    }
    public void FixedUpdate()
    {
        Vector2 motion = new Vector2(horizontal, vertical);
        motorsScript.Moviment(motion, speed);
    }

}
