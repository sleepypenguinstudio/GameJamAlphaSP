using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyClass : MonoBehaviour
{
      public enum AIState
    {
        Idle,
        Chase,
        Attack,
        Patroling
    }
    public AIState currentState;

    public Transform Player;

   

    private void Awake() {


       
        currentState = AIState.Chase;
    }
    private void Update()
    {
        FacePlayer();



        switch (currentState)
        {
            case AIState.Idle:
                Idle();
                break;
            case AIState.Chase:
                Chase(Player);
                break;
            case AIState.Attack:
                Attack(Player);
                break;
            case AIState.Patroling:
                Patroling(Player);
                break;
        }
    }


    protected virtual void Idle()
    {
        // Do nothing or random Move.
    }
    protected virtual void Chase(Transform player)
    {

    }


    protected virtual void Attack(Transform player)
    {

    }

    protected virtual void Patroling(Transform player)
    {

    }

     public void FacePlayer()
    {
        Vector3 direction = (Player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 50);
    }

}

