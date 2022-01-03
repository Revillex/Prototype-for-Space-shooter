using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    
    [SerializeField] Slider slider;
    [SerializeField] TextMeshProUGUI healthDisplay;

    void Start()
    {
        
    }

    void Update()
    {
        healthDisplay.text = slider.value.ToString();
    }

    public void ReduceHealth(int hp) 
    {
        slider.value -= hp;
    } 
}
