using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletArrangeInCircle : MonoBehaviour
{
    public int numberOfObjects = 10;
    public float radius = 5f;
    public Vector2 center = new Vector2(0, 0);
    public GameObject prefab;

    private void Start()
    {
        float angleStep = 360f / numberOfObjects;
        for (int i = 0; i < numberOfObjects; i++)
        {
            float angle = i * angleStep;
            Vector2 newPos = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)) * radius;
            GameObject newObj = Instantiate(prefab, transform);
            RectTransform rectTransform = newObj.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = newPos + center;
        }
    }
}
