using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KillerNavMesh : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] private GameObject deadPanel;

    private PlayerMovement _player;
    private NavMeshAgent agent;
    private bool stop;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        _player = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_player.isPlayerMoving)
        {
            agent.isStopped = true;
        }
        else
        {
            agent.isStopped = false;
        }
        agent.SetDestination(target.transform.position);

        float dist = Vector3.Distance(transform.position,target.transform.position);
        
        if (dist<=4.9f)
        {
            deadPanel.SetActive(true);
        }
        //Debug.Log(dist);
    }
}
