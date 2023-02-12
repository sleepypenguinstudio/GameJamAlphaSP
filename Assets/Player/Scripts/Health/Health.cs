using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{


    [SerializeField]  public float currentHealth;
    [SerializeField] float Maxhealth;



    private void Awake()
    {
        currentHealth = Maxhealth;
    }

    public void UpdateHealth(float damageValue)
    {


        currentHealth = HealthManager.Instance.DamageHealth(currentHealth,damageValue);

    }
    




    // Update is called once per frame
    void Update()
    {
        // if (currentHealth == 0)
        // {
        //     Destroy(this.gameObject);
        // }
        
    }
}
