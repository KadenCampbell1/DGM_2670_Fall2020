using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AIBehaviour : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform player;
    public bool canHunt, canPatrol;
    private WaitForFixedUpdate wffu = new WaitForFixedUpdate();

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private IEnumerator OnTriggerEnter(Collider other)
    {
        canHunt = true;
        while (canHunt)
        {
            yield return wffu;
            agent.destination = player.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        canHunt = false;
        canPatrol = true;
    }
}
