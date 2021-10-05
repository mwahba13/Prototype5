using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public bool isPlayerMoving;
    public float moveSpeed;

    public GameObject[] lightsToTurnOff;
    public AudioSource audioSource;

    private float stickX;
    private float stickY;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Gamepad gamepad = Gamepad.current;
        Keyboard keyboard = Keyboard.current;


        if (Input.GetJoystickNames().Length > 0)
        {
             stickX = gamepad.leftStick.ReadValue().x;
             stickY = gamepad.leftStick.ReadValue().y;

             if (gamepad.startButton.isPressed  || keyboard.rKey.isPressed)
             {
                 SceneManager.LoadScene(0);
             }

             if (stickX != 0 || stickY != 0)
             {
                 
             }
        }
        

        float keyX = Input.GetAxis("Horizontal");
        float keyY = Input.GetAxis("Vertical");


        if (keyboard.rKey.isPressed)
            SceneManager.LoadScene(0);
        
        if (stickX != 0 || stickY != 0 || keyX !=0 || keyY !=0)
        {
            isPlayerMoving = true;
            foreach (var light in lightsToTurnOff)
            {
                light.SetActive(false);
            }

            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }

            audioSource.mute = false;

            transform.position += new Vector3(stickX, stickY, 0f) * moveSpeed * Time.deltaTime;
           
            if (keyX != 0 || keyY != 0)
            {
                transform.position +=new Vector3(keyX, keyY, 0f) * moveSpeed * Time.deltaTime;
            }
            

            float heading = Mathf.Atan2(stickX, -stickY);

            if (keyX != 0 || keyY != 0)
            {
                 heading = Mathf.Atan2(keyX, -keyY);
            }
            transform.rotation=Quaternion.Euler(0f,0f,heading*Mathf.Rad2Deg);

        }
        else
        {
            audioSource.mute = true;
            isPlayerMoving = false;
            foreach (var light in lightsToTurnOff)
            {
                light.SetActive(true);
            }
        }
    }
}
