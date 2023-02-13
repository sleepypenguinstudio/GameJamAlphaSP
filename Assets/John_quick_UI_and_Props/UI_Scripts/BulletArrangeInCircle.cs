using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BulletArrangeInCircle : MonoBehaviour
{
    public int NumberOfBullets  ;
    public float radius = 5f;
    public Vector2 center = new Vector2(0, 0);
    public GameObject bullet;

    private GameObject[] objects;
    public GameObject[] gunPanels;
    private int currentPanelIndex = 0;

    private void Start()
    {
       

        CreateCircle();
    }

    private void Update()
    {

       
        if (Input.GetMouseButtonDown(0))
        {
            if ( objects.Length > 0)
            {
                Destroy(objects[objects.Length - 1]);
                GameObject[] newArray = new GameObject[objects.Length - 1];
                for (int i = 0; i < objects.Length - 1; i++)
                {
                    newArray[i] = objects[i];
                }
                objects = newArray;
            }
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            DestroyCircle();
            CreateCircle();
        }


        else if (Input.GetKeyDown(KeyCode.E))
        {
            ChangePanel();
            if (currentPanelIndex == 0)
            {
                NumberOfBullets = 20;
              
            }
            else if (currentPanelIndex == 1)
            {
                NumberOfBullets = 6;
               
            }

            else if (currentPanelIndex == 2)
            {
                NumberOfBullets = 30;
               
            }
            DestroyCircle();
            CreateCircle();
        }
    }


    public void DestroyCircle()
    {
        if (objects != null  )
        {
            foreach (GameObject obj in objects)
            {
                Destroy(obj);
            }
        }
    }
    public void CreateCircle()
    {

      
        
        float angleStep = 360f / NumberOfBullets;
        objects = new GameObject[NumberOfBullets];
        for (int i = 0; i < NumberOfBullets; i++)
        {
            float angle = i * angleStep;
            Vector2 newPos = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)) * radius;
            GameObject newObj = Instantiate(bullet, transform);
            RectTransform rectTransform = newObj.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = newPos + center;
            objects[i] = newObj;
        }
    }
    private void ChangePanel()
    {
        gunPanels[currentPanelIndex].SetActive(false);
        currentPanelIndex = (currentPanelIndex + 1) % gunPanels.Length;
        gunPanels[currentPanelIndex].SetActive(true);
        
    }
}
