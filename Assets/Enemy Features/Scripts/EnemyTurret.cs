using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : EnemyClass
{
     public GameObject projectile;
    protected override void TurretShoot(Transform player)
    {
        //call shoot function
        Debug.Log("Shooting");
        GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            Destroy(bullet,5.0f);
           // rb.AddForce(transform.up * 8f, ForceMode.Impulse);
    }
   
}
