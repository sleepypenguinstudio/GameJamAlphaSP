using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody rigidBody;
    private Vector3 playerVelocity;
    public float playerSpeed;
   

    void Update()
    {

      //  Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
       // rigidBody.MovePosition(transform.position + move * Time.deltaTime * playerSpeed);
    }
    
}
