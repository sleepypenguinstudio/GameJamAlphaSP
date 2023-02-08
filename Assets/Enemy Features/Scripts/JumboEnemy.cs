using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class JumboEnemy : EnemyClass
{

    [SerializeField] Transform[] PatrolPoints ;
    int currentWaypoint = 0; // Index of current waypoint
    public float speed = 5.0f; // Speed of movement
    Vector3 target;
 
     public NavMeshAgent agent;
    private void Awake() {

        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
        //Call Shoot function
    }
    
    protected override void Chase(Transform player)
    {
        if(Vector3.Distance(this.transform.position, target) < 1f)
        {
            Debug.Log("in");
            IterateWaypointIndex();
            UpdateDestination();
        }

    }

    void UpdateDestination()
    {
        target = PatrolPoints[currentWaypoint].position;
        Debug.Log(target+transform.position); 
         Debug.Log(target+transform.position); 

        agent.SetDestination(target);
    }

    void IterateWaypointIndex()
    {
        currentWaypoint++;
        if(currentWaypoint == PatrolPoints.Length)
        {
            currentWaypoint = 0;
        }
    }


}
