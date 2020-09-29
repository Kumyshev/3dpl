using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMov : MonoBehaviour
{
    public NavMeshAgent navMesh;


    public Vector3 walkDir;
    bool walkState;
    public float walkRange;


    private void Update()
    {
        Patroling();
    }

    private void Patroling() 
    {
        if (!walkState) SearchDir();

        if (walkState)
            navMesh.SetDestination(walkDir);

        Vector3 distanceToPoint = transform.position - walkDir;

        if (distanceToPoint.magnitude < 3f)
            walkState = false;
    }

    private void SearchDir() 
    {
        float rdmX = Random.Range(-walkRange, walkRange);
        float rdmZ = Random.Range(-walkRange, walkRange);

        walkDir = new Vector3(transform.position.x + rdmX, transform.position.y, transform.position.z + rdmZ);

        if (Physics.Raycast(walkDir, -transform.up, 2f)) 
        {
            walkState = true;
        }
    }
}
