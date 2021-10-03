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
    // Start is called before the first frame update
    void Start()
    {
        _playerMovement = playerObj.GetComponent<PlayerMovement>();
        _frontCheck = GetComponentInChildren<FrontCheck>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerMovement.isPlayerMoving)
        {
            if (!_frontCheck.isColliding)
            {
                
                
                
            }

            transform.position += -transform.up * moveSpeed * Time.deltaTime;
        }
        
    }
}
