using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BulletArrangeInCircle : MonoBehaviour
{
    [SerializeField]  int numberOfBullets  ;
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
            if (objects.Length > 0)
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
        else if (Input.GetMouseButtonDown(1))
        {
            DestroyCircle();
            CreateCircle();
        }


        else if (Input.GetKeyDown(KeyCode.E))
        {
            ChangePanel();
            if (currentPanelIndex == 0)
            {
                numberOfBullets = 20;
              
            }
            else if (currentPanelIndex == 1)
            {
                numberOfBullets = 6;
               
            }

            else if (currentPanelIndex == 2)
            {
                numberOfBullets = 30;
               
            }
            DestroyCircle();
            CreateCircle();
        }
    }


    private void DestroyCircle()
    {
        if (objects != null  )
        {
            foreach (GameObject obj in objects)
            {
                Destroy(obj);
            }
        }
    }
    private void CreateCircle()
    {

      
        
        float angleStep = 360f / numberOfBullets;
        objects = new GameObject[numberOfBullets];
        for (int i = 0; i < numberOfBullets; i++)
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
