using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class SliderManager : MonoBehaviour
{
    public TextMeshProUGUI sliderValue;
    public float _progress = 0;
    public Slider _slider;
    public void Update()
    {

    }

    public void UpdateProgress()
    {
        // progress = progress + 25f;
        _progress++;
        _slider.value = _progress;
        sliderValue.text = _progress.ToString();
    }
}
