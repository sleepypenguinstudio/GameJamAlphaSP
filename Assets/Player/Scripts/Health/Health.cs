using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


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
        if (currentHealth == 0 && gameObject.tag!="Player")
        {
            Destroy(this.gameObject);
        }
        else if (currentHealth==0)
        {
            Cursor.lockState = CursorLockMode.Confined;
            SceneManager.LoadScene(4);
            Destroy(this.gameObject);
            
        }
        
    }
}
