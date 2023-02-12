using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{

    public static HealthManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }


    public float DamageHealth(float currentHealth,float damage)
    {
        return (currentHealth - damage) < 0 ? 0 : currentHealth - damage;
    }




}
