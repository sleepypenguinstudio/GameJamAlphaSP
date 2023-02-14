using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterFly : MonoBehaviour
{
    public Animator HeliAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            FlyHelicopter();
        }
    }

    public void FlyHelicopter()
    {
        HeliAnimator.SetBool("flyHeli",true);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FlyHelicopter();
            Destroy(other.gameObject);
        }
    }
}
