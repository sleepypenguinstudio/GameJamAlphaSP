using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Newtonsoft.Json.Linq;

public class ProgressbarController : MonoBehaviour
{


    public TMP_Text displayText;
    public Slider slider;

  
    public float changeTime = 5f;
    float elapsedTime = 0f;

    void Start()
    {
       
        slider.onValueChanged.AddListener((value) =>
        {
            displayText.text = value.ToString("0.00");
        });
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= changeTime)
        {
            elapsedTime = changeTime;
        }
        slider.value = Mathf.Lerp(0, 20, elapsedTime / changeTime);
    }




}
