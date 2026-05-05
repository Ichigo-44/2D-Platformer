using UnityEngine;
using TMPro;
using JetBrains.Annotations;
using System;
public class UiHealthDesplay : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public HealthComponent healthComponent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        healthComponent.OnHealthChanged += OnHealthChanged;
        healthComponent.OnHealthInitialised += OnHealthChanged;
    }

    private void OnHealthChanged(float newHealth)
    {
        healthText.text = newHealth.ToString();
    }

    public void OnHealthChanged(float newHealth, float amountChanged)
    {
        healthText.text = newHealth.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
