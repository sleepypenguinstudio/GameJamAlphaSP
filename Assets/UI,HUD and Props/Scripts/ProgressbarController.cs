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

    public AudioSource audioSource;
    float songLength = 0f;
    float elapsedTime = 0f;

    void Start()
    {
        songLength = audioSource.clip.length;
        slider.maxValue = songLength;
        slider.onValueChanged.AddListener((value) =>
        {
            displayText.text = value.ToString("00.00");
        });
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= songLength)
        {
            elapsedTime = songLength;
        }
        slider.value = Mathf.Lerp(0, 30, elapsedTime / songLength);
    }




}
