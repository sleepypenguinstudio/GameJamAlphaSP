using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shatterable : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject shatteredObject;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    private void OnMouseDown()
    {
        Shatter();
    }
    public void Shatter()
    {
        Instantiate(shatteredObject, transform.position, transform.rotation);
        Destroy(gameObject);
    }

}
