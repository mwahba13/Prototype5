using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class KillerAI : MonoBehaviour
{

    public GameObject playerObj;
    public float moveSpeed;

    private PlayerMovement _playerMovement;

    private FrontCheck _frontCheck;

    private bool _isColliding;
    // Start is called before the first frame update
    void Start()
    {
        _playerMovement = playerObj.GetComponent<PlayerMovement>();
        //_frontCheck = GetComponentInChildren<FrontCheck>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerMovement.isPlayerMoving)
        {
            if (_isColliding)
            {
                transform.position += transform.up*.25f;
                transform.Rotate(0f,0f,45);
                
                
            }

            transform.position += -transform.up * moveSpeed * Time.deltaTime;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Wall"))
            _isColliding = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Wall"))
            _isColliding = false;
    }
}
