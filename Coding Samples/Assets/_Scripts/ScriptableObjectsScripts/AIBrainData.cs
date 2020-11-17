using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu]
public class AIBrainData : ScriptableObject
{
    public float health, speed;
    public List<Vector3Data> points;
    public Transform transform;
    public MeshFilter mesh;


    public virtual void Navigate(NavMeshAgent agent)
    {
        agent.destination = transform.position;
    }
}
