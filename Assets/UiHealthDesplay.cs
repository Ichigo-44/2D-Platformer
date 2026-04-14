using UnityEngine;
using TMPro;
using JetBrains.Annotations;
public class UiHealthDesplay : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public HealthComponent healthComponent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthComponent.OnHealthChanged += OnHealthChanged;
    }

    public void OnHealthChanged(int newHealth, int amountChanged)
    {
        //Debug.Log("On Health Changed Event");
        healthText.text = newHealth.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
