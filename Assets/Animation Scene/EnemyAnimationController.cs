using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    [SerializeField] private Animator enemyAnimator;
    public int animValue;

    // Start is called before the first frame update
    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
     {
    //    if(Input.GetKeyDown(KeyCode.Space))
    //     {
    //         PlayAnimation(animValue);
    //     }
    }

    public void PlayAnimation(int animationValue)
    {
        enemyAnimator.SetInteger("Enemy", animationValue);
    }
}
