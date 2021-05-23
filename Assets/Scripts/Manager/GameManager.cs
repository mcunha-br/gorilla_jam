using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameState state;



    public  void Awake()
    {
        instance = this;
    }

    public void ChangeState(GameState state)
    {
        this.state = state;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
