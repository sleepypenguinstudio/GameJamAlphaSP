using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float ThrowForce;
    public float ThrowExtraForce;
    public float RotationForce;





    public int WeaponGraphicsLayer;
    public GameObject WeaponGraphics;
    public Collider[] GraphicsColliders;

    private bool weaponEquipped;
    private Rigidbody _rigidBody;


    private void Start()
    {
        _rigidBody = gameObject.AddComponent<Rigidbody>();
        _rigidBody.mass = 0.1f;
    }


    public void PickUp(Transform weaponHolder)
    {
        if (weaponEquipped)
        {
            return;
        }
        Destroy(_rigidBody);
        transform.parent = weaponHolder;
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;

        foreach (var collider in GraphicsColliders)
        {
            collider.enabled = false;
        }

      
        weaponEquipped = true;

        
    }
    public void Drop(Transform playerCamera)
    {
        if (!weaponEquipped)
        {
            return;
        }

        _rigidBody = gameObject.AddComponent<Rigidbody>();
        _rigidBody.mass = 0.1f;
        Vector3 forwardDirection = playerCamera.forward;
        forwardDirection.y = 0f;

        _rigidBody.velocity = forwardDirection * ThrowForce;
        _rigidBody.velocity += Vector3.up * ThrowExtraForce;

        _rigidBody.angularVelocity = Random.onUnitSphere * RotationForce;


        transform.parent = null;
        weaponEquipped = false;
        foreach (var collider in GraphicsColliders)
        {
            collider.enabled = true;
        }
    }


}







