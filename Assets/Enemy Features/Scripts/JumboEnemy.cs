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

    //Weapon weapon;
 
     public NavMeshAgent agent;

 //   [SerializeField] public EnemyAnimationController EnemyAnimationController;
    public int AnimationValue = 3;

    
    private void Awake() {

        agent = GetComponent<NavMeshAgent>();
        EnemyAnimationController = GetComponent<EnemyAnimationController>();
        enemyHealth = GetComponent<Health>();
       // weapon = GetComponent<Weapon>();
        enemyShoot = GetComponent<EnemyShoot>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;



        EnemyAnimationController.PlayAnimation(AnimationValue);
        UpdateDestination();
       
    }
    
    protected override void Chase(Transform player)
    {
         
         EnemyAnimationController.PlayAnimation(AnimationValue);
          Vector3 moveDirection = (agent.destination - transform.position).normalized;
        if(Vector3.Distance(this.transform.position, target) < 6f)
        {
           // weapon.Shoot();
          
           
            Debug.Log("in");
            enemyShoot.MyInput();
            IterateWaypointIndex();
            UpdateDestination();
        }

    }

    void UpdateDestination()
    {
        target = PatrolPoints[currentWaypoint].position;
        // Debug.Log(target+transform.position); 
        //  Debug.Log(target+transform.position); 

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
