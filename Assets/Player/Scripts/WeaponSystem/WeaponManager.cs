using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using TMPro;
public class WeaponManager : MonoBehaviour
{

    public float PickUpRange;
    public float PickUpRadius;

    public float SwaySize;
    public float SwaySmooth;

    public int WeaponLayer;
    public Transform WeaponHolder;
    public Transform PlayerCamera;
    public Transform SwayHolder;
    public TMP_Text AmmoText;


    private bool isWeaponEquipped;
    private Weapon equippedWeapon;
    [SerializeField]private StarterAssetsInputs starterAssetsInputs;

    private void Awake()
    {
       // starterAssetsInputs = GetComponent<StarterAssetsInputs>();
    }

    private void Update()
    {
        if (isWeaponEquipped)
        {
            SwaySystem();          

            if (starterAssetsInputs.drop)
            {
                starterAssetsInputs.drop = false;
                equippedWeapon.Drop(PlayerCamera);
                equippedWeapon = null;
                isWeaponEquipped = false;

            }
        }
        else if (starterAssetsInputs.interact)
        {
            Debug.Log("DONE");
            starterAssetsInputs.interact = false;
            var hitList = new RaycastHit[256];
            var hitNumber = Physics.CapsuleCastNonAlloc(PlayerCamera.position, PlayerCamera.position + PlayerCamera.forward * PickUpRange, PickUpRadius, PlayerCamera.forward, hitList);

            var realList = new List<RaycastHit>();

            for (var i = 0; i < hitNumber; i++)
            {

                var hit = hitList[i];
                if (hit.transform.gameObject.layer != WeaponLayer)
                {
                    continue;
                }

                if (hit.point == Vector3.zero)
                {
                    realList.Add(hit);
                }
                else if (Physics.Raycast(PlayerCamera.position, hit.point - PlayerCamera.position, out var hitInfo, hit.distance + 0.1f) && hitInfo.transform == hit.transform)
                {
                    realList.Add(hit);
                }


            }

            if (realList.Count == 0)
            {
                return;
            }
            
            realList.Sort((hit1,hit2) => {
                var dist1 = GetDistance(hit1);
                var dist2 = GetDistance(hit2);
                return Mathf.Abs(dist1-dist2)<0.001f?0:dist1<dist2?-1:1;
            
            });
            isWeaponEquipped = true;
            equippedWeapon = realList[0].transform.GetComponent<Weapon>();
            equippedWeapon.PickUp(WeaponHolder,PlayerCamera,AmmoText);




        }
        
        
    }



    private float GetDistance(RaycastHit hit)
    {

        return Vector3.Distance(PlayerCamera.position,hit.point==Vector3.zero?hit.transform.position:hit.point);
    }


    private void SwaySystem()
    {
        var mouseDelta = -starterAssetsInputs.look;
        SwayHolder.localPosition = Vector3.Lerp(SwayHolder.localPosition, Vector3.zero, SwaySmooth * Time.deltaTime);
        SwayHolder.localPosition += (Vector3)mouseDelta * SwaySize;
    }




}
