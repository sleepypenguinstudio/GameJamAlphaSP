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
        Cover
    }
    public AIState currentState;

    public Transform Player;

    private float distanceToPlayer;
    public float health;

    private void Awake()
    {



    }
    private void Update()
    {
        FacePlayer();

        distanceToPlayer = Vector3.Distance(transform.position, Player.position);

        if (distanceToPlayer <= 20f)
        {
            currentState = AIState.Chase;
        }
        else if (distanceToPlayer > 20f && distanceToPlayer <= 30f)
        {
           currentState = AIState.Cover;

        }
        // else if (distanceToPlayer >= 30f)
        // {
        //     currentState = EnemyState.MoveEnemy;
        // }
        else
        {
           currentState = AIState.Idle;
        }

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
            case AIState.Cover:
                Cover(Player);
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

    protected virtual void Cover(Transform player)
    {

    }

    public void FacePlayer()
    {
        Vector3 direction = (Player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 50);
    }
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }
    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

}

