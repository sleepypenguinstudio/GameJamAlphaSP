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
        Death,
        Cover
    }
    public AIState currentState;

    public Transform Player;

    private float distanceToPlayer;
    public float health;
     Vector3 direction ;

    [SerializeField] public EnemyAnimationController EnemyAnimationController;
    [SerializeField] protected Health enemyHealth;

    //public Weapon weapon;
    [SerializeField] public EnemyShoot enemyShoot;

    private void Awake()
    {

        enemyHealth = GetComponent<Health>();

         EnemyAnimationController = GetComponent<EnemyAnimationController>();
         enemyShoot = GetComponent<EnemyShoot>();

        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
         //FacePlayer();
        distanceToPlayer = Vector3.Distance(transform.position, Player.position);

        if (distanceToPlayer <= 20f)
        {
            FacePlayer();
            currentState = AIState.Chase;
            // enemyShoot.MyInput();
        }
        else if (distanceToPlayer > 20f && distanceToPlayer <= 30f)
        {
          // currentState = AIState.Cover;
          FaceMovingDirection();
           currentState = AIState.Idle;

        }
        // else if (distanceToPlayer >= 30f)
        // {
        //     currentState = EnemyState.MoveEnemy;
        // }
        else
        {
            FaceMovingDirection();
           currentState = AIState.Cover;
        }

       if(enemyHealth.currentHealth <= 0)
       {
           currentState = AIState.Death;
       }
         
            if(Player)
            {
            switch (currentState)
            {

            case AIState.Idle:
                Idle();
                break;
            case AIState.Chase:
                Chase(Player);
                TurretShoot(Player);
                break;
            case AIState.Death:
                Death(Player);
                break;
            case AIState.Cover:
                Cover(Player);
                TurretShoot(Player);
                break;
                }
            }

    }


    protected virtual void Idle()
    {
        EnemyAnimationController.PlayAnimation(10);
    }
    protected virtual void Chase(Transform player)
    {

    }


    protected virtual void Death(Transform player)
    {
        //Death code
           EnemyAnimationController.PlayAnimation(14);
             Destroy(this.gameObject);
       
    }

    protected virtual void Cover(Transform player)
    {

    }

    protected virtual void TurretShoot(Transform player)
    {

    }

    public void FacePlayer()
    {
        Vector3 direction = (Player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 50);
    }


    public void FaceMovingDirection()
    {
       
       if (direction.magnitude > 0)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10.0f);
        }
    }



}

