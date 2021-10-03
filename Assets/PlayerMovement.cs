using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public bool isPlayerMoving;
    public float moveSpeed;

    public GameObject[] lightsToTurnOff;
    public AudioSource audioSource;
    
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

        if (stickX != 0 || stickY != 0)
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

            float heading = Mathf.Atan2(stickX, -stickY);
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
