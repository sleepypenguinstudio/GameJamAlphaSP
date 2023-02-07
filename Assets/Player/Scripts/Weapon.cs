using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
public class Weapon : MonoBehaviour
{
    [Header("Force related to Weapon Drop")]
    public float ThrowForce;
    public float ThrowExtraForce;
    public float RotationForce;





    [Header("Misceleinous")]
    public int WeaponGraphicsLayer;
    public GameObject[] WeaponGraphics;
    public Collider[] GraphicsColliders;
    [SerializeField] private StarterAssetsInputs starterAssetsInputs;



    [Header("Weapon Properties")]
    public int MaxAmmo;
    public int ShotsPerSecond;
    public float ReloadSpeed;
    public float HitForce;
    public float Range;
    public bool Tappable;

    private bool weaponEquipped;
    private Rigidbody _rigidBody;
    private bool reloading;
    private bool shooting;
    private int ammo;
    private Transform playerCamera;

    private void Start()
    {
        _rigidBody = gameObject.AddComponent<Rigidbody>();
        _rigidBody.mass = 0.1f;
        ammo = MaxAmmo;
    }



    private void Update()
    {
        if (!weaponEquipped) { return; }

        if (starterAssetsInputs.reload && !reloading && ammo<MaxAmmo)
        {
            starterAssetsInputs.reload = false;
            StartCoroutine(ReloadingCoolDown());
        }

        if((Tappable?Input.GetMouseButtonDown(0):Input.GetMouseButton(0))&& !shooting && !reloading)
        {

            ammo--;
            Shoot();
            StartCoroutine(ammo<=0? ReloadingCoolDown():ShootingCoolDown());

             


        }






    }





    private void Shoot()
    {
        if(!Physics.Raycast(playerCamera.position,playerCamera.forward,out var hitInfo, Range))
        {
            return;
        }
        
        var rigidBody = hitInfo.transform.GetComponent<Rigidbody>();
        if (rigidBody == null)
        {
            return;
        }
        rigidBody.velocity += playerCamera.forward * HitForce;
    }

    private IEnumerator ShootingCoolDown()
    {
        shooting = true;


        yield return new WaitForSeconds(1f/ShotsPerSecond);
        shooting = false;


    }



    private IEnumerator ReloadingCoolDown()
    {

        reloading = true;


        yield return new WaitForSeconds(ReloadSpeed);
        ammo = MaxAmmo;

        reloading = false;

    }

    













    public void PickUp(Transform weaponHolder,Transform _playerCamera)
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

        foreach (var gfx in WeaponGraphics)
        {
            gfx.layer = WeaponGraphicsLayer;
        }


        weaponEquipped = true;
        playerCamera = _playerCamera;

        
    }
    public void Drop(Transform playerCamera)
    {
        if (!weaponEquipped)
        {
            return;
        }
        foreach (var collider in GraphicsColliders)
        {
            collider.enabled = true;
        }
        foreach (var gfx in WeaponGraphics)
        {
            gfx.layer = 0;
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
       

    }


}







