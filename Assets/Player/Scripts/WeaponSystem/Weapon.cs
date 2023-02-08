using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using TMPro;
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
    public float AnimTime;



    [Header("Weapon Properties")]
    [SerializeField] int maxAmmo;
    [SerializeField] int maxClip;
    [SerializeField] int shotsPerSecond;
    [SerializeField] float reloadSpeed;
    [SerializeField] float hitForce;
    [SerializeField] float range;
    [SerializeField] bool tappable;
    [SerializeField] float recoilForce;
    [SerializeField] float recoilSmooth;
    [SerializeField] float damageValue;
    [SerializeField] GameObject bulletHolePrefab;




    private bool weaponEquipped;
    private Rigidbody _rigidBody;
    private bool reloading;
    private bool shooting;
    private int ammo;
    private Transform playerCamera;
    private TMP_Text ammoText;

    private Vector3 startPosition;
    private Quaternion startRotation;


    private float rotationTime;
    private float time;

    private void Start()
    {
        _rigidBody = gameObject.AddComponent<Rigidbody>();
        _rigidBody.mass = 1f;
        

        ammo = maxAmmo;
    }



    private void Update()
    {
        if (!weaponEquipped) { return; }



        if (time < AnimTime)
        {
            time += Time.deltaTime;
            time = Mathf.Clamp(time,0f,AnimTime);
            var delta = -(Mathf.Cos(Mathf.PI * (time / AnimTime)) - 1f) / 2f;
            transform.localPosition = Vector3.Lerp(startPosition,Vector3.zero,delta);
            transform.localRotation = Quaternion.Lerp(startRotation,Quaternion.identity,delta);
        }
        else
        {
            transform.localRotation = Quaternion.identity;
            transform.localPosition = Vector3.Lerp(transform.localPosition, Vector3.zero, recoilSmooth* Time.deltaTime);
        }


        if (reloading)
        {
            ReloadAnimation();
        }

        if (starterAssetsInputs.reload && !reloading && ammo<maxAmmo)
        {
            starterAssetsInputs.reload = false;
            StartCoroutine(ReloadingCoolDown());
        }
        else
        {
            starterAssetsInputs.reload = false;
        }

        if((tappable?Input.GetMouseButtonDown(0):Input.GetMouseButton(0))&& !shooting && !reloading && ammo>0)
        {

            ammo--;
           // ammoText.text = ammo + "/" + maxAmmo;
            Shoot();
            StartCoroutine(ammo<=0? ReloadingCoolDown():ShootingCoolDown());
            
        }
    }




    #region ShootMechanics
    private void Shoot()
    {
        transform.localPosition -= new Vector3(0, 0, recoilForce);


        if(!Physics.Raycast(playerCamera.position,playerCamera.forward,out var hitInfo, range))
        {
            return;
        }


        // Instantiate(BulletHole,hitInfo.point+(hitInfo.normal*0.1f),Quaternion.FromToRotation(Vector3.up,hitInfo.normal));
        if (hitInfo.collider.tag != "Enemy")
        {
            BulletHoleSystem(hitInfo);
        }
        
        if (hitInfo.transform.GetComponent<Rigidbody>())
        {
            var rigidBody = hitInfo.transform.GetComponent<Rigidbody>();
            rigidBody.velocity += playerCamera.forward * hitForce;
        }
       
         
        if (hitInfo.transform.GetComponent<Health>())
        {
            var health = hitInfo.transform.GetComponent<Health>();
            health.UpdateHealth(damageValue);
        }
    }

    private IEnumerator ShootingCoolDown()
    {
        shooting = true;


        yield return new WaitForSeconds(1f/shotsPerSecond);
        shooting = false;


    }

    private IEnumerator ReloadingCoolDown()
    {

        reloading = true;
        //ammoText.text = "Reloading";
        rotationTime = 0f;

        yield return new WaitForSeconds(reloadSpeed);
        ammo = maxAmmo;
       // ammoText.text = ammo + "/" + maxAmmo;

        reloading = false;
        starterAssetsInputs.reload = false;

    }

    private void ReloadAnimation()
    {
        rotationTime += Time.deltaTime;
        var spinDelta = -(Mathf.Cos(Mathf.PI * (rotationTime / reloadSpeed)) - 1f) / 2f;
        transform.localRotation = Quaternion.Euler(new Vector3(spinDelta * 360f, 0, 0));
    }
    #endregion


    #region PickUp & Drop Mechanics
    public void PickUp(Transform weaponHolder,Transform _playerCamera, TMP_Text _ammoText)
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
        ammoText = _ammoText;
       // ammoText.text = ammo + "/" + maxAmmo;

        
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
        _rigidBody.mass = 1f;
        
        Vector3 forwardDirection = playerCamera.forward;
        forwardDirection.y = 0f;

        //_rigidBody.AddForce(forwardDirection*ThrowForce,ForceMode.Impulse);
        _rigidBody.velocity = forwardDirection * ThrowForce;
        _rigidBody.velocity += Vector3.up * ThrowExtraForce;
        _rigidBody.collisionDetectionMode = CollisionDetectionMode.Continuous;

        _rigidBody.angularVelocity = Random.onUnitSphere * RotationForce;



       // ammoText.text = "";

        transform.parent = null;
        weaponEquipped = false;
       

    }

    #endregion



    private void BulletHoleSystem(RaycastHit hitInfo)
    {
        GameObject bulletMark = Instantiate(bulletHolePrefab,hitInfo.point,Quaternion.LookRotation(hitInfo.normal));
        
        bulletMark.transform.parent = hitInfo.transform;
        bulletMark.transform.position += bulletMark.transform.forward / 1000f;
        Destroy(bulletMark,10f);
    }



}







