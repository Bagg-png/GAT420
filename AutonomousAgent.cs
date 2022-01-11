using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutonomousAgent : Agent
{
    [SerializeField] Perception perception;
    [SerializeField] Steering steering;

    public Vector3 velocity { get; set; } = Vector3.zero;

    void Update()
    {
        Vector3 acceleration = Vector3.zero;

        GameObject[] gameObjects = perception.GetGameObjects();
        if (gameObjects.Length == 0) acceleration += steering.Wander(this);
        if(gameObjects.Length != 0)
        {
            Debug.DrawLine(transform.position, gameObjects[0].transform.position);
            acceleration += steering.Flee(this, gameObjects[0]);

        }

        velocity += acceleration * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
        transform.position = Utilites.Wrap(transform.position, new Vector3(-10, -10, -10), new Vector3(10, 10, 10));
    }
}
