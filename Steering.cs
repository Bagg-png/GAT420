using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steering : MonoBehaviour
{
    [Range(0, 45)] public float wanderDisplacement = 5;
    [Range(0, 5)] public float wanderRadius = 3;
    [Range(0, 5)] public float wanderDistance = 1;
    float wanderAngle = 0;
    public Vector3 Flee(AutonomousAgent agent, GameObject gameObject)
    {
        Vector3 direction = (agent.transform.position - gameObject.transform.position).normalized;
        return direction * 2;
    }
    public Vector3 Seek(AutonomousAgent agent, GameObject gameObject)
    {
        Vector3 direction = (gameObject.transform.position - agent.transform.position).normalized;
        return direction * 2;
    }
    public Vector3 Wander(AutonomousAgent agent)
    {
        wanderAngle += Random.Range(-wanderDistance, wanderDistance);
        Quaternion rotation = Quaternion.AngleAxis(wanderAngle, Vector3.up);
        Vector3 point = rotation * (Vector3.forward * wanderRadius);
        Vector3 forward = agent.transform.forward * wanderDistance;
        Vector3 direction = CalculateSteering(agent, forward + point);
        return direction * 2;
    }

    public Vector3 CalculateSteering(AutonomousAgent agent, Vector3 force)
    {
        return (force - agent.transform.position).normalized * 2;
    }
}
