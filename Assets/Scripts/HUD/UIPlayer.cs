using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIPlayer : MonoBehaviour
{   
    public Slider SldLife;

    PlayerMotor playerMotor;


    private void Start()
    {
        playerMotor = FindObjectOfType<PlayerMotor>();
    }
    // Update is called once per frame
    void Update()
    {
        SldLife.value = playerMotor.life;
    }
}
