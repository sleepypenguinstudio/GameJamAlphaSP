using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kickable : MonoBehaviour
{

    public float forceAmount = 10.0f;
    public Vector3 newPosition = new Vector3(0, 0, 0);
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.forward * forceAmount, ForceMode.Impulse);
            transform.position = newPosition;
        }
    }
}
