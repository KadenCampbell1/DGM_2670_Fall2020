using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(InstancerBehaviour))]
public class NavAgentWithBrainBehaviour : MonoBehaviour
{

    public AIBrainData brain;
    public List<AIBrainData> brainDatas;
    private GameObject obj;
    private InstancerBehaviour instance;
    private int i = 0;
    
    private NavMeshAgent agent;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = GetComponent<InstancerBehaviour>();
        agent = GetComponent<NavMeshAgent>();
        brain = brainDatas[i];
        obj = brain.prefab;
        instance.InstanceObj(obj);
    }

    // Update is called once per frame
    void Update()
    {
        //brain.Navigate(agent);
    }

    private void OnTriggerEnter(Collider other)
    {
        brain = brainDatas[i];
        obj = brain.prefab;
        instance.InstanceObj(obj);

        if (i < brainDatas.Count)
        {
            i++;
        }
    }
}
