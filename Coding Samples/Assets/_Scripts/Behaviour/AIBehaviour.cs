using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AIBehaviour : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform player;
    public bool canHunt, canPatrol;
    private WaitForFixedUpdate wffu = new WaitForFixedUpdate();
    private WaitForSeconds wfs = new WaitForSeconds(2f);
    public List<Transform> patrolPoints;
    private int i = 0;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        i = 0;
        StartCoroutine(Patrol());
    }

    private IEnumerator Patrol()
    {
        canPatrol = true;
        canHunt = false;
        while (canPatrol)
        {
            yield return wffu;
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                yield return wfs;
                agent.destination = patrolPoints[i].position;
                i = (i + 1) % patrolPoints.Count;
                
            }
        }
    }
    
    private IEnumerator OnTriggerEnter(Collider other)
    {
        canHunt = true;
        canPatrol = false;
        while (canHunt)
        {
            yield return wffu;
            agent.destination = player.position;
        }
    }

    private IEnumerator OnTriggerExit(Collider other)
    {
        yield return wfs;
        StartCoroutine(Patrol());
    }
}
