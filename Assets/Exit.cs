using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public bool playerHasKey = false;
    public GameObject winCondition;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && playerHasKey)
        {
            winCondition.SetActive(true);
        }
    }
}
