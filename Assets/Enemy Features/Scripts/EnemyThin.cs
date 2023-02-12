using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyThin : EnemyClass
{
    [SerializeField] NavMeshAgent agent;
    // [SerializeField] Transform player;
    public int FrameInterval = 10;


    Vector3 randomPosition;
    Vector3 coverPoint;
    public float RangeRandomPoint = 6f;
    public bool IsHiding = false;

    public LayerMask CoverLayer;
    Vector3 coverObject;
    public LayerMask VisibleLayer;

    private float maxCoverDistance = 30;
    public bool CoverIsClose;
    public bool CoverNotReached = true;

    public float DistanceToCoverPosition = 1f;
    public float DistanceToCoverObject;

    public float RangeDistance = 15f;
    private bool playerInRange = false;

    private int testCoverPosition = 10;


     [SerializeField] public EnemyAnimationController EnemyAnimationController;
    public int AnimationValue = 3;
    private void Awake()
    {
          EnemyAnimationController = GetComponent<EnemyAnimationController>();

       EnemyAnimationController.PlayAnimation(AnimationValue);

        agent = GetComponent<NavMeshAgent>();
        //Move();
    }



    protected override void Cover(Transform player)
    {


        if (agent.isActiveAndEnabled)
        {
            if (Time.frameCount % FrameInterval == 0)
            {
                float distance = ((player.position - transform.position).sqrMagnitude);

                if (distance < RangeDistance * RangeDistance)
                {
                    playerInRange = true;
                }
                else
                {
                    playerInRange = false;
                }
            }

            if (playerInRange == true)
            {
                CheckCoverDistance();

                if (CoverIsClose == true)
                {
                    if (CoverNotReached == true)
                    {
                        agent.SetDestination(coverObject);
                    }
                    if (CoverNotReached == false)
                    {
                        GoTOCover();

                    }
                }
                if (CoverIsClose == false)
                {
                    // call shooting functtion
                }
            }

        }
    }



    bool RandomCoverPoint(Vector3 center, float RangeRandomPoint, out Vector3 resultCover)
    {
        for (int i = 0; i < testCoverPosition; i++)
        {
            randomPosition = center + Random.insideUnitSphere * RangeRandomPoint;
            Vector3 direction = Player.position - randomPosition;
            RaycastHit hitTestCover;
            if (Physics.Raycast(randomPosition, direction.normalized, out hitTestCover, RangeRandomPoint, VisibleLayer))
            {
                if (hitTestCover.collider.gameObject.layer == 18)
                {
                    resultCover = randomPosition;
                    return true;
                }
            }
        }
        resultCover = Vector3.zero;
        return false;
    }



    void CheckCoverDistance()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, maxCoverDistance, CoverLayer);
        Collider nearestCollider = null;
        float minSqrDistance = Mathf.Infinity;

        Vector3 AiPosition = transform.position;

        for (int i = 0; i < colliders.Length; i++)
        {
            float sqrDistanceToCenter = (AiPosition - colliders[i].transform.position).sqrMagnitude;
            if (sqrDistanceToCenter < minSqrDistance)
            {
                minSqrDistance = sqrDistanceToCenter;
                nearestCollider = colliders[i];


                float coverDistance = (nearestCollider.transform.position - AiPosition).sqrMagnitude;

                if (coverDistance <= maxCoverDistance * maxCoverDistance)
                {
                    CoverIsClose = true;
                    coverObject = nearestCollider.transform.position;

                    if (coverDistance <= DistanceToCoverObject * DistanceToCoverObject)
                    {
                        CoverNotReached = false;
                    }
                    else if (coverDistance > DistanceToCoverObject * DistanceToCoverObject)
                    {
                        CoverNotReached = true;
                    }

                }


                if (coverDistance > maxCoverDistance * maxCoverDistance)
                {
                    CoverIsClose = false;

                }
            }
        }

        if (colliders.Length < 1)
        {
            CoverIsClose = false;
        }
    }

    void GoTOCover()
    {
        if (RandomCoverPoint(transform.position, RangeRandomPoint, out coverPoint))
        {
            if (agent.isActiveAndEnabled)
            {
                agent.SetDestination(coverPoint);
                if ((coverPoint - transform.position).sqrMagnitude <= DistanceToCoverPosition * DistanceToCoverPosition)
                {
                    IsHiding = true;
                }
            }
        }
    }

}
