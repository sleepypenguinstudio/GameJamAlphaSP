using UnityEngine;
using TMPro;

public class EnemyShoot : MonoBehaviour
{
    //Gun stats
    public int damage;
    public float timeBetweenShooting, spread, range, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    //public bool allowButtonHold;
    int bulletsLeft, bulletsShot;

    Health healthResolver;

    //bools  
    bool shooting, readyToShoot, reloading;
    

    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask whatIsPlayer;
    [SerializeField] ParticleGroupEmitter[] shootParticle;


    private void Awake()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;
        healthResolver = GetComponent<Health>();
    }
    private void Update()
    {
       // MyInput();

        //SetText
       // text.SetText(bulletsLeft + " / " + magazineSize);
    }
    public void MyInput()
    {
        // if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        // else shooting = Input.GetKeyDown(KeyCode.Mouse0);

         if ( bulletsLeft < magazineSize && !reloading) Reload();

        //Shoot
        if (!reloading && bulletsLeft > 0){
            bulletsShot = bulletsPerTap;
            Shoot();
        }
    }
    public void Shoot()
    {



        foreach (var e in shootParticle)
        {
            e.Emit(1);
        }





        readyToShoot = false;

        //Spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //Calculate Direction with Spread
        //Vector3 direction = pl.transform.forward + new Vector3(x, y, 0);

        //RayCast
        if (Physics.Raycast(transform.position, transform.forward, out rayHit, range))
        {
            Debug.Log("Shoot in");
            Debug.Log(rayHit.collider.name);

            if (rayHit.collider.CompareTag("Player"))
            {
                //Damage function
                Debug.Log("Fire");
                Debug.DrawLine(transform.position,transform.position + transform.forward *50, Color.green);
                rayHit.collider.GetComponent<Health>().UpdateHealth(damage);

                bulletsLeft--;
                bulletsShot--;
            }
                
        }

        //ShakeCamera
       // camShake.Shake(camShakeDuration, camShakeMagnitude);

        //Graphics
        // Instantiate(bulletHoleGraphic, rayHit.point, Quaternion.Euler(0, 180, 0));
        // Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);


        Invoke("ResetShot", timeBetweenShooting);

        if(bulletsShot > 0 && bulletsLeft > 0)
        Invoke("Shoot", timeBetweenShots);
    }
    public void ResetShot()
    {
        readyToShoot = true;
    }
    public void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }
    public void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }
}
