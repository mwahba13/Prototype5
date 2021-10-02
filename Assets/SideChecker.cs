using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SideChecker : MonoBehaviour
{
    public bool isRightSide;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision: " + isRightSide);
        
        Gamepad gamepad = Gamepad.current;
        
        if(isRightSide)
            gamepad.SetMotorSpeeds(0.0f,0.5f);
        else
            gamepad.SetMotorSpeeds(0.5f,0.0f);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Gamepad gamepad = Gamepad.current;
        
        if(isRightSide)
            gamepad.SetMotorSpeeds(0.0f,0.0f);
        else
            gamepad.SetMotorSpeeds(0.0f,0.0f);
    }
}
