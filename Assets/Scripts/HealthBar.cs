using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
     private Slider healthSlider;
    private Quaternion startRotation;
    private void LateUpdate()
    {
        transform.rotation = startRotation;
    }
    private void Awake()
    {
        startRotation = transform.rotation;
        healthSlider = GetComponent<Slider>();
    }
    public void UpdateHealthBar(int maxHealth, int currentHealth)
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.minValue = 0;
        healthSlider.value = currentHealth;
    }
}
