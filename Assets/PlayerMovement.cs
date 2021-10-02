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

        transform.position += new Vector3(gamepad.leftStick.ReadValue().x, gamepad.leftStick.ReadValue().y, 0)
            *Time.deltaTime*moveSpeed;
        
    }
}
