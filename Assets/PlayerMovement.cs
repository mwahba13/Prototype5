using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour

{
    public GameObject blackScreen;
    
    public float moveSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Gamepad gamepad = Gamepad.current;
        float stickX = gamepad.leftStick.ReadValue().x;
        float stickY = gamepad.leftStick.ReadValue().y;
        
        if(stickX != 0 || stickY != 0)
            blackScreen.SetActive(true);
        else 
            blackScreen.SetActive(false);
        
        transform.position += new Vector3(stickX, stickY, 0)*Time.deltaTime*moveSpeed;
        
    }
}
